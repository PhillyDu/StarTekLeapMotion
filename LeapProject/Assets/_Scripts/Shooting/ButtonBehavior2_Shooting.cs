using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior2_Shooting : MonoBehaviour
{
    public Material redButtonMaterial;

    private Renderer buttonRenderer;

    // Start is called before the first frame update
    void Start()
    {
        buttonRenderer = GetComponent<MeshRenderer>();
    }

    public void OnButtonPress()
    {
        buttonRenderer.material = redButtonMaterial;
    }
}
