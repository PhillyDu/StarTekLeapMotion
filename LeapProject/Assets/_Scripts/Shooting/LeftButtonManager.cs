using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButtonManager : MonoBehaviour
{
    public GameObject buttonLeft;
    public GameObject dualButtonManager;
    public Material redButtonMaterial;

    private DualButtonManager dualManager;
    private Renderer buttonLeftRenderer;

    // Start is called before the first frame update
    void Start()
    {
        buttonLeftRenderer = GetComponent<MeshRenderer>();
        dualManager = dualButtonManager.GetComponent<DualButtonManager>();
    }

    public void OnLeftClick()
    {
        buttonLeftRenderer.material = redButtonMaterial;
    }
}
