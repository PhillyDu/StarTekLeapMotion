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
    public GameObject muzzleFlash;
    public float damage = 10f;
    public float range = 50f;
    public float fireRate = 15f;
    public float reticleRange = 10f;
    public Vector3 offset;

    private bool isAiming;
    private bool isShooting;
    private Vector3 direction;
    private Vector3 reticlePosition;
    private float nextTimeToFire = 0f;

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
            reticlePosition = direction * reticleRange;
            Aim();
            if(isShooting && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + (1f / fireRate);
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
    }

    void Shoot()
    {
        GameObject muzzleFlashEffect = Instantiate(muzzleFlash,
            pistol.transform.GetChild(0).gameObject.transform.position,
            Quaternion.LookRotation(direction));
        Destroy(muzzleFlashEffect, 0.25f);
        if (Physics.Raycast(pointerIndex.transform.position, direction, out hit, range))
        {
            Destroy(hit.transform.gameObject);
        }
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
