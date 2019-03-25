using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualButtonManager : MonoBehaviour
{
    public GameObject doors;
    public GameObject buttonLeft;
    public GameObject buttonRight;
    public Material redButtonMaterial;

    private DoorManager doorManager;
    private Renderer buttonLeftRenderer;
    private Renderer buttonRightRenderer;
    // Start is called before the first frame update
    void Start()
    {
        doorManager = doors.GetComponent<DoorManager>();
        buttonLeftRenderer = buttonLeft.GetComponent<MeshRenderer>();
        buttonRightRenderer = buttonRight.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if((buttonLeftRenderer.material == redButtonMaterial) && (buttonRightRenderer.material == redButtonMaterial))
        {
            doorManager.Unlock();
        }
    }
}
