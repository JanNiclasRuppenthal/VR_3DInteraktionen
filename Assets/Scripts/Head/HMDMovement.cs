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
    private Vector3 _startPos;
    private readonly float _baseMovement = 5f;
    private readonly float _deadzone = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = centerEye.transform.position;
    }

    void LateUpdate()
    {
        Vector3 hmdLocomotion = centerEye.transform.position - _startPos;
        hmdLocomotion.y = 0;
        hmdLocomotion.x = 0;
        if (hmdLocomotion.magnitude > _deadzone)
        {
            float movement = _baseMovement * hmdLocomotion.magnitude;
            if (hmdLocomotion.z < 0)
            {
                locomotion.position -= locomotion.transform.forward * movement * Time.deltaTime;
            }
            else
            {
                locomotion.position += locomotion.transform.forward * movement * Time.deltaTime;
            }

        }
    }
}