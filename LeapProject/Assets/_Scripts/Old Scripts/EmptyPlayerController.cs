using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPlayerController : MonoBehaviour
{
    public GameObject vehicle;

    private float tempX;
    private float tempY;
    private float tempZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tempX = vehicle.transform.position.x - 0.1f;
        tempY = vehicle.transform.position.y;
        tempZ = vehicle.transform.position.z - 1.5f;
        transform.position = new Vector3(tempX, tempY, tempZ);
    }
}
