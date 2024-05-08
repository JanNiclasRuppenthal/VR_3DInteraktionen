using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    void Update()
    {
        RotateItSelf();
    }
    
    public void RotateItSelf()
    {
        this.transform.Rotate(Vector3.up, 90 * Time.deltaTime, Space.Self);
    }
}
