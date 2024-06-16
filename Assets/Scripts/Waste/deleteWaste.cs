using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class deleteWaste : XRGrabInteractable
{
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        if (tag == "Waste")
        {
            GameObject.FindObjectOfType<WasteStats>().setCollected();
            Destroy(gameObject);
        }
    }
}
