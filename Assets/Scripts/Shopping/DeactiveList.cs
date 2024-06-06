using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveList : MonoBehaviour
{
    private bool _active = true;
    [SerializeField] private MeshRenderer listTextMesh;
    [SerializeField] private MeshRenderer articlesTextMesh;

    private bool triggerWasPressed = false;

    // Update is called once per frame
    void Update()
    {
        if (checkIndexTriggerPressed())
        {
            // _active = !_active;
            // this.setActiveShoppingList(_active);
            triggerWasPressed = true;
        }
        else if (triggerWasPressed)
        {
            triggerWasPressed = false;
            _active = !_active;
            this.setActiveShoppingList(_active);
        }
    }
    
    private bool checkIndexTriggerPressed()
    {
        return Input.GetKeyDown(KeyCode.Space) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) ||
               OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger);
    }


    private void setActiveShoppingList(bool active)
    {
        this.listTextMesh.enabled = active;
        this.articlesTextMesh.enabled = active;
    }
}
