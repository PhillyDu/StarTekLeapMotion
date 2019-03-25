﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior_Shooting : MonoBehaviour
{
    public float doorForce;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnOpen()
    {
        rb.AddForce(Vector3.forward * doorForce);
    }
}
