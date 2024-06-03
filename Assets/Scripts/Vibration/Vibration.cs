using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vibration : MonoBehaviour
{
    public bool activeVib = false;
    private float amplitude = 0f;
    // Start is called before the first frame update
    void Start()
    {
        OVRInput.EnableSimultaneousHandsAndControllers();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeVib)
        {
            startVib();
        }
        else
        {
            stopVib();
        }
    }
    public void setAmplitude(float a, float max)
    {
        amplitude = a/max;
    }
    public void startVib()
    {
        OVRInput.SetControllerVibration(1, amplitude, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(1, amplitude, OVRInput.Controller.LTouch);
    }
    public void stopVib()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }
    
}
