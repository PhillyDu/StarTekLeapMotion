using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Shooting : MonoBehaviour
{
    public Transform pointerIndex;
    public Transform pointerBase;
    public PistolController pistolController;

    private bool isAiming;
    private bool isFiring;
    private bool isReloading;

    private Vector3 initialPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        isAiming = false;
        isFiring = false;
        isReloading = false;

        initialPlayerPosition = transform.position;
        //pistolController = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAimingStart()
    {
        isAiming = true;
    }

    public void OnAimingEnd()
    {
        isAiming = false;
    }

    public void OnFiringStart()
    {
        isFiring = true;
    }

    public void OnFiringEnd()
    {
        isFiring = false;
    }

    public void OnReloadingStart()
    {
        isReloading = true;
    }

    public void OnReloadingEnd()
    {
        isReloading = false;
    }
}
