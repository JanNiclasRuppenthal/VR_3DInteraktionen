using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class activateWall : MonoBehaviour
{
    public GameObject wall;
    bool active = false;

    public InputActionProperty button;

    // Update is called once per frame
    void Update()
    {
        if (wall.gameObject.name != "Wand mitte")
        {
            if (Input.GetKeyDown(KeyCode.W) || button.action.WasPressedThisFrame())
            {
                active = wall.activeSelf;
                wall.SetActive(!active);
            }
        }
        else
        {
            if (button.action.WasPressedThisFrame())
            {
                active = wall.activeSelf;
                wall.SetActive(!active);
            }
        }
        
    }
}
