using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButtonManager : MonoBehaviour
{
    public GameObject buttonRight;
    public GameObject dualButtonManager;
    public Material redButtonMaterial;

    private DualButtonManager dualManager;
    private Renderer buttonRightRenderer;

    // Start is called before the first frame update
    void Start()
    {
        buttonRightRenderer = GetComponent<MeshRenderer>();
        dualManager = dualButtonManager.GetComponent<DualButtonManager>();
    }

    public void OnRightClick()
    {
        buttonRightRenderer.material = redButtonMaterial;
    }
}
