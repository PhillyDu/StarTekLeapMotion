using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Shooting : MonoBehaviour
{
    public Transform pointerIndex;
    public Transform pointerBase;
    public Transform muzzleFlashOrigin;
    public GameObject pistol;
    public GameObject reticle;
    public GameObject muzzleFlashReference;
    public GameObject impactEffectReference;

    public float damage = 10f;
    public float range = 50f;
    public float fireRate = 2f;
    public float impactForce = 35f;

    private float nextTimeToFire = 0f;
    private float speed;

    private Vector3 initialPlayerPosition;
    private Vector3 previousPlayerPosition;
    private Vector3 movementOffset;
    private Vector3 direction;
    private bool isAiming;
    private bool isShooting;
    private RaycastHit hit;
    private int layerMask;

    void Start()
    {
        isAiming = false;
        isShooting = false;
        pistol.SetActive(false);
        reticle.SetActive(false);
        initialPlayerPosition = transform.position;
        previousPlayerPosition = transform.position;
        speed = GetComponent<TravelPath>().translationSpeed;
        layerMask = 1 << 9;
        layerMask = ~layerMask;
    }

    void FixedUpdate()
    {
        movementOffset = (transform.position - previousPlayerPosition) * speed * speed;
        if(isAiming)
        {
            direction = Vector3.Normalize(pointerIndex.position - pointerBase.position);
            Aim();
            if(isShooting && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + (1f / fireRate);
                Shoot();
            }
        }
        previousPlayerPosition = transform.position;
    }

    private void Aim()
    {
        pistol.transform.position = pointerBase.position;
        pistol.transform.rotation = Quaternion.LookRotation(direction);
        if(Physics.Raycast(pointerIndex.position, direction, out hit, range, layerMask))
        {
            reticle.transform.position = hit.point;
            reticle.transform.rotation = Quaternion.LookRotation(hit.normal);
        }

    }

    private void Shoot()
    {
        GameObject muzzleFlashEffect = Instantiate(muzzleFlashReference, 
            muzzleFlashOrigin.position + movementOffset, Quaternion.LookRotation(direction));
        Destroy(muzzleFlashEffect, 0.25f);
        if(Physics.Raycast(pointerIndex.position, direction, out hit, range, layerMask))
        {
            GameObject impactEffect = Instantiate(impactEffectReference, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactEffect, 0.2f);
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            EnemyBehavior_Shooting enemy = hit.transform.GetComponent<EnemyBehavior_Shooting>();
            LockedDoorController door = hit.transform.GetComponent<LockedDoorController>();
            ButtonBehavior2_Shooting button = hit.transform.GetComponent<ButtonBehavior2_Shooting>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            if(door != null)
            {
                door.OnHit();
            }
            if(button != null)
            {
                button.OnButtonPress();
            }
        }
    }

    public void OnAimingStart()
    {
        isAiming = true;
        pistol.SetActive(true);
        reticle.SetActive(true);
    }

    public void OnAimingEnd()
    {
        isAiming = false;
        pistol.SetActive(false);
        reticle.SetActive(false);
    }

    public void OnShootingStart()
    {
        isShooting = true;
    }

    public void OnShootingEnd()
    {
        isShooting = false;
    }
}
