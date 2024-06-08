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
    [SerializeField]
    private GameObject segway;
    private readonly float _baseMovement = 7.5f;
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
        if (Mathf.Abs(hmdLocomotion.z) > _deadzone)
        {
            if(hmdLocomotion.z < 0)
            {
                hmdLocomotion.z += _deadzone;
                _movement = -(Mathf.Pow(_baseMovement * hmdLocomotion.z, _times));
            }
            else
            {
                hmdLocomotion.z -= _deadzone;
                _movement = Mathf.Pow(_baseMovement * hmdLocomotion.z, _times);
            }
            _movement = Mathf.Clamp(_movement, -_maxMovement, _maxMovement);
            locomotion.position += locomotion.transform.forward * _movement * Time.deltaTime;
            vibration.GetComponent<Vibration>().activeVib = true;
            vibration.GetComponent<Vibration>().setAmplitude(Mathf.Abs(_movement), _maxMovement);

            segway.GetComponent<Move>().movement = _movement;
        }
        else if(vibration.GetComponent<Vibration>().activeVib == true)
        {
            vibration.GetComponent<Vibration>().activeVib = false;
            segway.GetComponent<Move>().movement = 0f;
        }
    }
}