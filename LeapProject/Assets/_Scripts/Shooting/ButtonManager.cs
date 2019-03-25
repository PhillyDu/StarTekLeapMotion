using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject doors;
    public Material redButtonMaterial;

    private Renderer buttonRenderer;
    private DoorManager doorManager;

    // Start is called before the first frame update
    void Start()
    {
        buttonRenderer = GetComponent<MeshRenderer>();
        doorManager = doors.GetComponent<DoorManager>();
    }

    public void OnClicked()
    {
        buttonRenderer.material = redButtonMaterial;
        doorManager.Unlock();
    }
}
