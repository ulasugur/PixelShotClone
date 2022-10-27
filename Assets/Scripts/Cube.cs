using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Rigidbody rb;
    GameObject Ground;
    MeshRenderer mr;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        Ground = GameObject.Find("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        rb.useGravity = true;
        mr.material.color = Color.red;
        
        if (collision.gameObject==Ground)
        {
            Destroy(gameObject);
        }
        
    }

}
