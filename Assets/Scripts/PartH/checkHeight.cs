using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHeight : MonoBehaviour
{
    public bool enabled = true;
    Rigidbody rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= 5 && enabled){
            rb.useGravity = false;
            this.GetComponent<AngryBirdActivity>().enabled = true;
            this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            enabled = false;
        }
        
    }
}
