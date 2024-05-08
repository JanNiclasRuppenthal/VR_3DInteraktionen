using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationVariable : MonoBehaviour
{
    [SerializeField]
    [Range(-180, 180)]
    private float angle = 0;
    
    void Update()
    {
        RotateItSelf();
    }
    
    public void RotateItSelf()
    {
        this.transform.Rotate(Vector3.up, angle * Time.deltaTime, Space.Self);
    }
}
