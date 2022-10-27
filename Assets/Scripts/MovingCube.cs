using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    [SerializeField] float speed;

    public Vector3 startPos1;
    public Vector3 startPos2;

    public Transform currentPoint;
    public GameObject MoveCube;


    private void Awake()
    {
        startPos1=MoveCube.transform.position;
    }
    private void Update()
    {
        MoveCube.transform.position=Vector3.MoveTowards(MoveCube.transform.position,startPos1,speed*Time.deltaTime);
        if (MoveCube.transform.position==startPos1)
        {
            startPos1 = startPos2;
            if (startPos1==startPos2)
            {
                startPos2 = MoveCube.transform.position;
            }
        }
    }   
}
