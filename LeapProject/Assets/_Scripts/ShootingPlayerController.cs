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
    public GameObject impact;
    public float damage = 10f;
    public float range = 50f;
    public float fireRate = 15f;
    public float reticleRange = 10f;
    public float impactForce = 30f;

    private bool isAiming;
    private bool isShooting;
    private Vector3 direction;
    private float nextTimeToFire = 0f;
    private float reticleOffsetX;
    private float reticleOffsetY = 0.4f;
    private float reticleOffsetZ = 0f;
    private Vector3 reticleOffset;
    private Vector3 pistolOffset;

    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        pistolOffset.x = -0.025f;
        pistolOffset.y = 0f;
        pistolOffset.z = 0f;
        reticleOffset.y = 0.4f;
        reticleOffset.z = 0f;
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
        pistol.transform.position = pointerBase.transform.position + pistolOffset;
        pistol.transform.rotation = Quaternion.LookRotation(direction);
        reticleOffset.x = direction.x * 2.5f;
        reticle.transform.position = (direction * reticleRange) + reticleOffset;
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
            GameObject impactEffect = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactEffect, 0.2f);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            TargetBehavior target = hit.transform.GetComponent<TargetBehavior>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
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
