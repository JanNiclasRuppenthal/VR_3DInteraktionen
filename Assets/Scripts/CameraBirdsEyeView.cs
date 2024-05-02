using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Serialization;

public class CameraBirdsEyeMovement : MonoBehaviour
{
    
    private float speed;
    private Vector3 targetPosition;
    
    
    public bool isRotating;

    public void initializeBirdEye(Vector3 targetPosition, float speed)
    {
        this.targetPosition = targetPosition;
        this.speed = speed;
    }
    

    public void movement()
    {
        float vertical = speed * Time.deltaTime;
        transform.RotateAround(targetPosition, Vector3.right, vertical);
        this.transform.LookAt(targetPosition);
        
    }
    
}
