using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR;

public class HMDMovement : MonoBehaviour
{
    [FormerlySerializedAs("Locomotion")] [SerializeField]
    private Transform locomotion;
    [SerializeField]
    private Transform centerEye;
    [SerializeField]
    private GameObject vibration;
    private readonly float _baseMovement = 5f;
    private readonly float _maxMovement = 5f;
    private readonly float _deadzone = 0.05f;
    private readonly float _times = 2f;
    private float _movement = 0f;


    // Start is called before the first frame update
    void Start()
    {
        //_startPos = centerEye.transform.position;
    }

    void LateUpdate()
    {
        Vector3 hmdLocomotion = centerEye.transform.localPosition;
        hmdLocomotion.y = 0;
        hmdLocomotion.x = 0;
        //Debug.Log("HMD");
        //Debug.Log(hmdLocomotion);
        if (Mathf.Abs(hmdLocomotion.z) > _deadzone)
        {
            hmdLocomotion.z -= _deadzone;
            if(hmdLocomotion.z < 0)
            {
                _movement = -(Mathf.Pow(_baseMovement * hmdLocomotion.z, _times));
            }
            else
            {
                _movement = Mathf.Pow(_baseMovement * hmdLocomotion.z, _times);
            }
            _movement = Mathf.Clamp(_movement, -_maxMovement, _maxMovement);
            //Debug.Log("movement");
            //ebug.Log(_movement);
            locomotion.position += locomotion.transform.forward * _movement * Time.deltaTime;
            vibration.GetComponent<Vibration>().activeVib = true;
            vibration.GetComponent<Vibration>().setAmplitude(Mathf.Abs(_movement), _maxMovement);
        }
        else if(vibration.GetComponent<Vibration>().activeVib == true)
        {
            vibration.GetComponent<Vibration>().activeVib = false;
        }
    }
}