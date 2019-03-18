using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingGesture : GestureBase
{
    public EHand leftHand;
    public EHand rightHand;

    [Range(0.0f, 1.0f)]
    public float closedPercentage = 0.6f;


    public override bool Detected()
    {
        if (DetectionManager.Get().IsHandSet(leftHand) && DetectionManager.Get().IsHandSet(rightHand))
        {
            return DetectionManager.Get().GetHand(leftHand).IsClosed(closedPercentage) && DetectionManager.Get().GetHand(rightHand).IsClosed(closedPercentage);
        }

        return false;
    }
}

