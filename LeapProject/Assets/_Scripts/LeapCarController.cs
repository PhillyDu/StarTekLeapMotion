using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LeapAxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class LeapCarController : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;

    public List<LeapAxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    private float startTime;
    private float inputTorque = 0.0f;
    private bool isDriving = false;

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * inputTorque;
        float steering = maxSteeringAngle * GetSteeringAngle();

        foreach (LeapAxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

    public void OnDrivingStart()
    {
        startTime = Time.time;
        inputTorque = 0.5f;
        isDriving = true;
    }

    public void OnDrivingStay()
    {
        if(Time.time - startTime > 1)
        {
            inputTorque = 0.75f;
        }
        if(Time.time - startTime > 2)
        {
            inputTorque = 1;
        }
    }

    public void OnDrivingEnd()
    {
        inputTorque = 0.0f;
        isDriving = false;
    }

    public float GetSteeringAngle()
    {
        if(isDriving)
        {
            float temp = leftHand.transform.position.y - rightHand.transform.position.y;
            if (temp >= 45)
            {
                return 45;
            }
            else if (temp <= -45)
            {
                return -45;
            }
            else
            {
                return temp;
            }
        } else
        {
            return 0;
        }
    }
}
