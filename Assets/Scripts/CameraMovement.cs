using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private Vector3 targetPosition;
    
    private Vector3 offset;
    private bool isRotating;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - targetPosition;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRotating = !isRotating;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
         //TODO: We need to stop at a specific position or the camera is going back to its initial position

        if (isRotating)
        {
            float vertical = speed * Time.deltaTime;

            transform.RotateAround(targetPosition, Vector3.right, vertical);

            this.transform.LookAt(targetPosition);
        }
    }
}
