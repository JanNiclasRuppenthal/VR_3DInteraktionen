using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honk : MonoBehaviour
{
    private AudioSource honkSource;

    private void Start()
    {
        this.honkSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.checkHandTriggerPressed())
        {
            honkSource.Play();
        }
    }

    private bool checkHandTriggerPressed()
    {
        return OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) ||
               OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);
    }
}
