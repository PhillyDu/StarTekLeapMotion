using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSideController : MonoBehaviour
{
    public GameObject controlButton;
    public Material redButtonMaterial;
    public bool isPressedRight;
    // Start is called before the first frame update
    void Start()
    {
        isPressedRight = false;
    }

    void Update()
    {
        if (controlButton.GetComponent<MeshRenderer>().material == redButtonMaterial)
        {
            isPressedRight = true;
        }
    }
}