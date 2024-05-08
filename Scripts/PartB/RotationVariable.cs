using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationVariable : MonoBehaviour
{
    [Range(-180, 180)]
    public float angle = 0;
    
    void Update()
    {
        RotateItSelf();
    }
    
    public void RotateItSelf()
    {
        this.transform.Rotate(Vector3.up, this.angle * Time.deltaTime, Space.Self);
    }
}
