using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public Material redButtonMaterial;

    public GameObject doorLeft;
    public GameObject doorRight;
    private bool isPressed;
    private Renderer buttonRenderer;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        buttonRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPress()
    {
        isPressed = true;
        buttonRenderer.material = redButtonMaterial;
        if(doorLeft != null)
        {
            Destroy(doorLeft.transform.gameObject);
        }
        if(doorRight != null)
        {
            Destroy(doorRight.transform.gameObject);
        }
    }
}
