using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private Transform lineTransform;
    [SerializeField] private float rotationSpeed;
    
    // Update is called once per frame
    void Update()
    {
        lineTransform.eulerAngles -= new Vector3(0, 0, rotationSpeed * Time.deltaTime);
    }
    
    
    

   
}
