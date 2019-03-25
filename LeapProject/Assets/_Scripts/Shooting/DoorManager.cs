using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;

    public void Unlock()
    {
        Destroy(leftDoor);
        Destroy(rightDoor);
    }
}
