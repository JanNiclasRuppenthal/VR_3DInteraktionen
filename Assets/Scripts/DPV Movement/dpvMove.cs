using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class dpvMove : MonoBehaviour
{
    [SerializeField]
    private XRGrabInteractable grabO;
    [SerializeField]
    private GameObject locomotion;
    [SerializeField]
    private GameObject dpv;
    [SerializeField]
    private InputActionProperty button;
    [SerializeField]
    private float maxSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(grabO.interactorsSelecting.Count == 2)
        {
            Vector3 direction = dpv.transform.forward;
            float bIntensity = button.action.ReadValue<float>();
            locomotion.transform.position += maxSpeed * direction * bIntensity * Time.deltaTime;
        }
    }
}
