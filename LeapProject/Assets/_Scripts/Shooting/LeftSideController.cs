using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSideController : MonoBehaviour
{
    public GameObject controlButton;
    public Material redButtonMaterial;
    public bool isPressedLeft;
    // Start is called before the first frame update
    void Start()
    {
        isPressedLeft = false;
    }

    void Update()
    {
        if(controlButton.GetComponent<MeshRenderer>().material == redButtonMaterial)
        {
            isPressedLeft = true;
        }
    }
}
