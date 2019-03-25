﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameObject using this script must have Rigidbody Component
// and have IsKinematic checked.

// In GamePath include event system to trigger function for rotation start and target for LookAt function
public class TranslatePath : MonoBehaviour
{
    public GamePath gamePath;
    public float translationSpeed = 1f;
    public float rotationSpeed = 1f;
    public float maxDistanceToGoal = 0.1f;

    private IEnumerator<Transform> pointInPath;
    private Vector3 nextPosition;
    private Quaternion nextRotation;
    private float distanceSquared;
    private float maxDistanceToGoalSquared;

    // Start is called before the first frame update
    void Start()
    {
        if(gamePath == null)
        {
            Debug.LogError("Game path cannot be null, must specify a path to traverse.", gameObject);
            return;
        }

        pointInPath = gamePath.GetNextPathPoint();
        Debug.Log(pointInPath.Current);

        pointInPath.MoveNext();
        Debug.Log(pointInPath.Current);

        if(pointInPath.Current == null)
        {
            Debug.LogError("A path must have points in it to be traversed.", gameObject);
            return;
        }

        transform.position = pointInPath.Current.position;

        maxDistanceToGoalSquared = maxDistanceToGoal * maxDistanceToGoal;
    }

    // Direction vector = endPosition - startPosition
    // Square Magnitude can be taken from either end - start or start - end
    // because of the square the negative is removed from the expression
    // Update is called once per frame
    void FixedUpdate()
    {
        if(pointInPath == null || pointInPath.Current == null)
        {
            return;
        }

        nextPosition = pointInPath.Current.position - transform.position;
        nextRotation = pointInPath.Current.rotation;

        transform.Translate(Vector3.Normalize(nextPosition) * translationSpeed * Time.deltaTime, Space.World);
        if(transform.rotation != nextRotation)
        {
            transform.Rotate(Vector3.Cross(transform.forward, pointInPath.Current.forward),
                rotationSpeed * Time.deltaTime, Space.World);
        }

        distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if(distanceSquared < maxDistanceToGoalSquared)
        {
            pointInPath.MoveNext();
        }
    }
}
