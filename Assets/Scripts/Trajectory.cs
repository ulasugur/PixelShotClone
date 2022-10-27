using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Trajectory : MonoBehaviour
{

    private Scene _SimutalionScene;
    private PhysicsScene _physicsScene;

    [SerializeField] private Transform _GridParents;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private int _maxPhysicsFrameIterations;

    private void Start()
    {
        CreatePhysicScene();
    }

    void CreatePhysicScene()
    {
        _SimutalionScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        _physicsScene=_SimutalionScene.GetPhysicsScene();

        foreach (Transform obj in _GridParents)
        {
            var ghostObj = Instantiate(obj.gameObject,obj.position,obj.rotation);
            ghostObj.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(ghostObj, _SimutalionScene);
        }
    }
    public void SimulateTrajectory(Ball ballPrefab, Vector3 pos, Vector3 velocity)
    {
        var ghostObj = Instantiate(ballPrefab, pos, Quaternion.identity);
        SceneManager.MoveGameObjectToScene(ghostObj.gameObject, _SimutalionScene);

        ghostObj.Shoot(velocity);
        _line.positionCount = _maxPhysicsFrameIterations;

        for (int i = 0; i < _maxPhysicsFrameIterations; i++)
        {
            _physicsScene.Simulate(Time.fixedDeltaTime);
            _line.SetPosition(i,ghostObj.transform.position);
        }

        Destroy(ghostObj.gameObject);
    }

}
