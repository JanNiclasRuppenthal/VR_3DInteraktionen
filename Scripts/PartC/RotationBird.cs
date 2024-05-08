using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBird : MonoBehaviour
{

    [SerializeField] private GameObject oakTree;

    // Update is called once per frame
    void Update()
    {
        float angle = oakTree.GetComponent<RotationVariable>().angle;
        this.transform.RotateAround(oakTree.transform.position, Vector3.up, angle * Time.deltaTime);
    }
}
