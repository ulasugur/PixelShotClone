using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public List<GameObject> Obj;
    private void Start()
    {
        Obj = new List<GameObject>();
        Obj.Add(GameObject.FindWithTag("Cube"));
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(Obj[0]);
    }
}
