using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior_Shooting : MonoBehaviour
{
    public Material redButtonMaterial;

    private Renderer buttonRenderer;

    // Start is called before the first frame update
    void Start()
    {
        buttonRenderer = GetComponent<MeshRenderer>();
    }

    public void OnPress()
    {
        buttonRenderer.material = redButtonMaterial;
    }
}
