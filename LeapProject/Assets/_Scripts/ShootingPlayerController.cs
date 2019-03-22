using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayerController : MonoBehaviour
{
    public GameObject pointerIndex;
    public GameObject pointerBase;
    public GameObject player;

    public GameObject pistol;
    public GameObject reticle;
    public GameObject muzzleFlash;
    public GameObject impact;
    public float damage = 10f;
    public float range = 50f;
    public float fireRate = 2f;
    public float impactForce = 35f;

    private Vector3 movementOffset;
    private bool isAiming;
    private bool isShooting;
    private Vector3 direction;
    private float nextTimeToFire = 0f;

    private Vector3 initialPlayerPosition;
    private float speed;

    Rigidbody rb;
    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        isAiming = false;
        isShooting = false;
        pistol.SetActive(false);
        reticle.SetActive(false);
        rb = player.GetComponent<Rigidbody>();
        speed = player.GetComponent<FollowPath>().translationSpeed;
        initialPlayerPosition = player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementOffset = (player.transform.position - initialPlayerPosition) * speed * speed;
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
        initialPlayerPosition = player.transform.position;
    }

    void Aim()
    {
        pistol.transform.position = pointerBase.transform.position;
        pistol.transform.rotation = Quaternion.LookRotation(direction);
        if (Physics.Raycast(pointerIndex.transform.position, direction, out hit, range))
        {
            reticle.transform.position = hit.point;
            reticle.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
    }

    void Shoot()
    {
        GameObject muzzleFlashEffect = Instantiate(muzzleFlash,
            pistol.transform.GetChild(0).gameObject.transform.position + movementOffset,
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
