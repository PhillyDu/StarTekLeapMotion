using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePath : MonoBehaviour
{
    public int movingTo = 0;
    public Transform[] pathSequence;

    private int movementDirection = 1;

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if(pathSequence == null || pathSequence.Length < 1)
        {
            yield break;
        }
        while(true)
        {
            yield return pathSequence[movingTo];
            if(pathSequence.Length == 1)
            {
                continue;
            }
            movingTo += movementDirection;
        }
    }
}
