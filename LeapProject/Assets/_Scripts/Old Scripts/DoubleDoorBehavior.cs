using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorBehavior : MonoBehaviour
{
    public GameObject button;
    public GameObject door;
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
        if(door != null)
        {
            Destroy(door.transform.gameObject);
        }
    }
}
