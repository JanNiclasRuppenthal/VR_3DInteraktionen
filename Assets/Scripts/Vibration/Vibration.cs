using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vibration : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        OVRInput.EnableSimultaneousHandsAndControllers();
    }

    // Update is called once per frame
    void Update()
    {
        Vib();
    }
    
    
    public void Vib()
    {
        Invoke("startVib", .1f);
        Invoke("stopVib", .4f);
    }
    public void startVib()
    {
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
    }
    public void stopVib()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
    
}
