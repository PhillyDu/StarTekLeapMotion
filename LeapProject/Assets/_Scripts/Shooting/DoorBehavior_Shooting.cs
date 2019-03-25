using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior_Shooting : MonoBehaviour
{
    public Transform oppositeDoor;
    public float doorForce;

    private Rigidbody rb;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = transform.position - oppositeDoor.position;
    }

    public void OnOpen()
    {
        rb.AddForce(direction * doorForce);
    }
}
