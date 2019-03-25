using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorController2 : MonoBehaviour
{
    public GameObject left;
    public GameObject right;

    private LeftSideController leftSide;
    private RightSideController rightSide;
    private DoorBehavior_Shooting leftDoor;
    private DoorBehavior_Shooting rightDoor;

    // Start is called before the first frame update
    void Start()
    {
        leftSide = left.transform.GetComponent<LeftSideController>();
        rightSide = right.transform.GetComponent<RightSideController>();
        leftDoor = left.transform.GetChild(1).gameObject.transform.GetComponent<DoorBehavior_Shooting>();
        rightDoor = right.transform.GetChild(1).gameObject.transform.GetComponent<DoorBehavior_Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if(leftSide.isPressedLeft && rightSide.isPressedRight)
        {
            leftDoor.OnOpen();
            rightDoor.OnOpen();
        }
    }
}
