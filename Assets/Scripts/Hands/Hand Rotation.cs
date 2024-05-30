using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotation : MonoBehaviour
{
    [SerializeField]
    private Transform Origin;
    [SerializeField]
    private Transform lHand;
    [SerializeField]
    private Transform rHand;
    private float baseRotation = 45f;
    private float deadzone = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 mid = (lHand.position + rHand.position)/2;
        //Debug.Log(mid);
        Vector3 relativeMid = Origin.InverseTransformPoint(mid);
        if (relativeMid.x > deadzone)
        {
            Origin.Rotate(0, relativeMid.x * baseRotation * Time.deltaTime, 0);
        }else if (relativeMid.x < -deadzone)
        {
            Origin.Rotate(0, relativeMid.x * baseRotation * Time.deltaTime, 0);
        }
    }
}
