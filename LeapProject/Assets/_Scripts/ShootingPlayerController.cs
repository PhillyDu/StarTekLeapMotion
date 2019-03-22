using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayerController : MonoBehaviour
{

    // pointerIndex and pointerBase used to calculate direction vector
    // pistol
    public GameObject pointerIndex;
    public GameObject pointerBase;

    public GameObject pistol;
    public GameObject reticle;
    public float damage = 10f;
    public float range = 50f;
    public float fireRate = 0.25f;

    private bool isAiming;
    private bool isShooting;
    private Vector3 direction;

    Ray ray;
    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        isAiming = false;
        isShooting = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isAiming)
        {
            direction = pointerIndex.transform.position - pointerBase.transform.position;
            Aim();
            if(isShooting)
            {
                Shoot();
            }
        }
    }

    void Aim()
    {

    }

    void Shoot()
    {

    }

    public void OnAimingStart()
    {
        pistol.SetActive(true);
        reticle.SetActive(true);
        isAiming = true;
    }

    public void OnAimingStay()
    {

    }

    public void OnAimingEnd()
    {
        isAiming = false;
    }

    public void OnShootingStart()
    {
        isShooting = true;
    }

    public void OnShootingStay()
    {
        
    }

    public void OnShootingEnd()
    {
        isShooting = false;
    }
}
