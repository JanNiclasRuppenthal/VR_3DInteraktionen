using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    void Update()
    {
        RotateItSelf();
    }
    
    public void RotateItSelf(float angle = 90)
    {
        this.transform.Rotate(Vector3.up, angle * Time.deltaTime, Space.Self);
    }
}
