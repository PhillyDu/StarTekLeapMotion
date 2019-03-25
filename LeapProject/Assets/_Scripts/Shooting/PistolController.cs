using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    public GameObject reticle;
    public GameObject muzzleFlash;
    public GameObject impactEffect;
    public Transform muzzleFlashLocation;

    public float damage = 10f;
    public float range = 25f;
    public float fireRate = 2f;
    public float impactForce = 35f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.active = false;
        reticle.SetActive(false);
    }
}
