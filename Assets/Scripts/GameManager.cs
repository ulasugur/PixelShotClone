using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Ball;
    [SerializeField] private GameObject[] Cube;


    public GameObject Finish;
    // Start is called before the first frame update
    void Start()
    {
        new List<GameObject>();
        GameObject.Find("Sphere");
        Finish = GameObject.Find("Finish");
        Finish.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        Cube = GameObject.FindGameObjectsWithTag("Block");

        if (GameObject.Find("Sphere") == null && GameObject.Find("Sphere(Clone)") == null) 
        { 
            Instantiate(Ball);
        }

        if (Cube.Length <=0)
        {
            Finish.SetActive(true);  
        }

        
    }
}
