using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMDMovement : MonoBehaviour
{
    [SerializeField]
    private Transform Origin;
    private Vector3 startPos;
    private float baseMovement = 5f;
    private float deadzone = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.CenterEye, devices);
        if (devices.Count > 0)
        {
            InputDevice device = devices[0];
            if (device.TryGetFeatureValue(CommonUsages.centerEyePosition, out startPos))
            {
                Origin.position = startPos;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    void LateUpdate()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.CenterEye, devices);
        if(devices.Count > 0)
        {
            InputDevice device = devices[0];
            Vector3 hmdPos;
            if(device.TryGetFeatureValue(CommonUsages.centerEyePosition, out hmdPos)){

                Vector3 hmdLocomotion = hmdPos - startPos;
                hmdLocomotion.y = 0;
                hmdLocomotion.x = 0;
                if(hmdLocomotion.magnitude > deadzone)
                {
                    float movement = baseMovement * hmdLocomotion.magnitude;
                    if (hmdLocomotion.z < 0)
                    {
                        Origin.position -= Origin.transform.forward * movement * Time.deltaTime;
                    }
                    else
                    {
                        Origin.position += Origin.transform.forward * movement * Time.deltaTime;
                    }
                   
                }
            }
        }
    }
}
