using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
public class Ball : MonoBehaviour
{
    private Vector3 PressDownPos;
    private Vector3 ReleasePos;
    private Vector3 UpdatePos;

    private GameObject Ground;
    public GameObject BallPrefab;

    private LineRenderer lr;
    private Rigidbody rb;
    private SphereCollider Sp;


    private bool isShoot;
    [SerializeField] private float ForceMulti;

    [SerializeField] private Trajectory _projection;
    // Start is called before the first frame update
    void Start()
    {
        lr=GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
        Sp = GetComponent<SphereCollider>();
        Ground = GameObject.Find("Ground");
        rb.useGravity = false;
        Sp.isTrigger= true;
    }
    
    // Update is called once per frame
    void Update()
    {
        //_projection.SimulateTrajectory(this,PressDownPos,ReleasePos*ForceMulti);
        UpdatePos = Input.mousePosition;
    }

    private void OnMouseDown()
    {
        PressDownPos = Input.mousePosition;

    }
    private void OnMouseUp()
    {
        ReleasePos=Input.mousePosition;
        Shoot(Force:PressDownPos - ReleasePos);
    }
    public void Shoot(Vector3 Force)
    {
        if (isShoot)
        {
            return;
        }
        Sp.isTrigger = false;
        rb.useGravity=true;

        rb.AddForce(new Vector3 (-Force.x, Force.y)*ForceMulti);
        isShoot = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject==Ground)
        {
            Destroy(gameObject);
        }
    }
        
    
}
