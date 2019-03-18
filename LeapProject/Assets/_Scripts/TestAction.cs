using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAction : MonoBehaviour
{

    Rigidbody rb;
    private bool isDriving;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isDriving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isDriving)
        {
            rb.AddForce(0, 0, 1);
        }
    }

    public void OnDrivingStart()
    {
        isDriving = true;
    }

    public void OnDrivingEnd()
    {
        isDriving = false;
    }
}
