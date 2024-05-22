using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBirdVariableLook : MonoBehaviour
{
    [SerializeField] private GameObject oakTree;
    [Range(-180, 180)]
    public float angle = 90;

    
    
    void Update()
    {
        RotateItSelf();
    }
    
    public void RotateItSelf()
    {
        this.transform.RotateAround(oakTree.transform.position, Vector3.up, this.angle * Time.deltaTime);

        Vector3 vectorTree = (oakTree.transform.position - this.transform.position).normalized;
        //Vector3 vectorUp = (Vector3.up - this.transform.position).normalized;

        Vector3 tangent = Vector3.Cross(vectorTree, Vector3.up).normalized;
        if (angle < 0) tangent = -tangent;
        this.transform.LookAt(this.transform.position + tangent);
    }
}