using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public GameObject button;
    public GameObject leftDoor;
    public GameObject rightDoor;
    public Material redButtonMaterial;

    private Renderer buttonRenderer;
    // Start is called before the first frame update
    void Start()
    {
        buttonRenderer = button.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPress()
    {
        buttonRenderer.material = redButtonMaterial;
        if(leftDoor != null)
        {
            Destroy(leftDoor.transform.gameObject);
        }
        if(rightDoor != null)
        {
            Destroy(rightDoor.transform.gameObject);
        }
    }
}
