using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorController : MonoBehaviour
{
    private ButtonBehavior_Shooting button;
    private DoorBehavior_Shooting leftDoor;
    private DoorBehavior_Shooting rightDoor;

    // Start is called before the first frame update
    void Start()
    {
        button = transform.GetChild(0).gameObject.transform.GetComponent<ButtonBehavior_Shooting>();
        leftDoor = transform.GetChild(1).gameObject.transform.GetComponent<DoorBehavior_Shooting>();
        rightDoor = transform.GetChild(2).gameObject.transform.GetComponent<DoorBehavior_Shooting>();
    }

    public void OnHit()
    {
        button.OnPress();
        leftDoor.OnOpen();
        rightDoor.OnOpen();
    }
}
