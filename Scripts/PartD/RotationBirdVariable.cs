using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBirdVariable : MonoBehaviour
{
    [SerializeField] private GameObject oakTree;
    [Range(-180, 180)]
    public float angle = 0;
    
    
    void Update()
    {
        RotateItSelf();
    }
    
    public void RotateItSelf()
    {
        this.transform.RotateAround(oakTree.transform.position, Vector3.up, this.angle * Time.deltaTime);
    }
}