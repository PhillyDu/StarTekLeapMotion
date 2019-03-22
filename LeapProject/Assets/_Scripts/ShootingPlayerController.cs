using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayerController : MonoBehaviour
{

    // pointerIndex and pointerBase used to calculate direction vector
    // pistol
    public GameObject pointerIndex;
    public GameObject pointerBase;
    public GameObject muzzleFlashLocation;

    public GameObject pistol;
    public GameObject reticle;
    public float damage = 10f;
    public float range = 50f;
    public float fireRate = 0.25f;
    public Vector3 offset;

    private bool isAiming;
    private bool isShooting;
    private Vector3 direction;
    private Vector3 reticlePosition;

    Ray ray;
    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        isAiming = false;
        isShooting = false;
        pistol.SetActive(false);
        reticle.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isAiming)
        {
            direction = -(pointerBase.transform.position - pointerIndex.transform.position);
            reticlePosition = direction * 10f;
            Aim();
            if(isShooting)
            {
                Shoot();
            }
        }
    }

    void Aim()
    {
        pistol.transform.position = pointerBase.transform.position + offset;
        pistol.transform.rotation = Quaternion.LookRotation(direction);
        reticle.transform.position = reticlePosition;
        reticle.transform.rotation = Quaternion.identity;
        if(Physics.Raycast(pointerIndex.transform.position, direction, out hit, range))
        {

        }
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
        pistol.SetActive(false);
        reticle.SetActive(false);
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
