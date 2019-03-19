using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayerController : MonoBehaviour
{
    public GameObject pointerIndex;
    public GameObject pointerBase;
    public GameObject reticle;
    public float range = 50f;

    Ray ray;
    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ray = new Ray(pointerIndex.transform.position, pointerIndex.transform.TransformDirection(Vector3.right));

        Debug.DrawRay(pointerIndex.transform.position, pointerIndex.transform.TransformDirection(Vector3.right) * range, Color.yellow);

        if(Physics.Raycast(pointerIndex.transform.position, pointerIndex.transform.TransformDirection(Vector3.right), out hit, range))
        {
            reticle.transform.position = hit.transform.position;
        }
    }

    public void OnShootingStart()
    {
        //Enable reticle
        reticle.SetActive(true);
    }

    public void OnShootingStay()
    {
        //Aiming
        
    }

    public void OnShootingEnd()
    {
        //Disable reticle
        reticle.SetActive(false);
    }
}
