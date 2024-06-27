using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class deleteWaste : XRGrabInteractable
{
    GameObject wasteSpawner;
    void Start(){
        wasteSpawner =  GameObject.Find("WasteSpawner");
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        if (tag == "Waste")
        {
            GameObject.FindObjectOfType<WasteStats>().setCollected();
            wasteSpawner.GetComponent<spawnWaste>().cnt -= 1;
            Destroy(gameObject);
        }
    }
}
