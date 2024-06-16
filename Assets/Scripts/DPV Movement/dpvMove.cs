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
    private GameObject rotor;
    [SerializeField]
    private GameObject vibration;
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
        if(grabO.interactorsSelecting.Count >= 1)
        {
            Vector3 direction = dpv.transform.forward;
            float bIntensity = button.action.ReadValue<float>();
            if(bIntensity > 0f)
            {
                vibration.GetComponent<Vibration>().activeVib = true;
                vibration.GetComponent<Vibration>().setAmplitude(bIntensity);
            }
            else
            {
                vibration.GetComponent<Vibration>().activeVib = false;
                rotor.GetComponent<rotorMove>().SetMovement(0f);
            }
            float speed = maxSpeed * bIntensity;
            rotor.GetComponent<rotorMove>().SetMovement(speed);
            locomotion.transform.position += speed * direction * Time.deltaTime;
        }else if (vibration.GetComponent<Vibration>().activeVib == true)
        {
            vibration.GetComponent<Vibration>().activeVib = false;
            rotor.GetComponent<rotorMove>().SetMovement(0f);
        }
    }
}
