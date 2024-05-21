using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

public class BowStringController : MonoBehaviour
{
    [SerializeField]
    private BowString bowStringRenderer;

    [SerializeField]
    private Transform midPointGrabObject, midPointVisualObject, midPointParent;

    [SerializeField] 
    private float bowStringStretchLimit = 0.5f;

    private XRGrabInteractable _interactable;
    private Transform _interactor;
    private float _strength;
    private AudioSource audioPig;
    
    
    public UnityEvent onBowPulled;
    public UnityEvent<float> onBowReleased;

    private void Awake()
    {
        _interactable = midPointGrabObject.GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        _interactable.selectEntered.AddListener(PrepareBowString);
        _interactable.selectExited.AddListener(ResetBowString);
        
        // audio
        audioPig = this.GetComponent<AudioSource>();
    }

    private void PrepareBowString(SelectEnterEventArgs arg0)
    {
        _interactor = arg0.interactorObject.transform;
        onBowPulled?.Invoke();
    }

    private void ResetBowString(SelectExitEventArgs arg0)
    {
        onBowReleased?.Invoke(_strength);
        _strength = 0;
        
        _interactable = null;
        midPointGrabObject.localPosition = Vector3.zero;
        midPointVisualObject.localPosition = Vector3.zero;
        bowStringRenderer.CreateString(null);
        
        audioPig.Play(0);
    }


    private void Update()
    {
        if (_interactor != null)
        {
            //convert bow string mid point to the local space of the mid point
            Vector3 midPointLocalSpace = midPointParent.InverseTransformPoint(midPointGrabObject.position);
            
            //get the offset
            float midPointLocalZAbs = Mathf.Abs(midPointLocalSpace.z);

            HandleStringPushedBackToStart(midPointLocalSpace);
            HandleStringPulledBackToLimit(midPointLocalZAbs, midPointLocalSpace);
            HandlePullingString(midPointLocalZAbs, midPointLocalSpace);
            
            bowStringRenderer.CreateString(midPointVisualObject.position);
        }
    }

    private void HandlePullingString(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        //what happens when we are between point 0 and the string pull limit
        if (midPointLocalSpace.z < 0 && midPointLocalZAbs < bowStringStretchLimit)
        {
            _strength = Remap(midPointLocalZAbs, 0, bowStringStretchLimit, 0, 1);
            midPointVisualObject.localPosition = new Vector3(0, 0, midPointLocalSpace.z);
        }
    }

    private float Remap(float value, int fromMin, float fromMax, int toMin, int toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }

    private void HandleStringPulledBackToLimit(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        //We specify max pulling limit for the string. We don't allow the string to go any farther than "bowStringStretchLimit"
        if (midPointLocalSpace.z < 0 && midPointLocalZAbs >= bowStringStretchLimit)
        {
            _strength = 1;
            //Vector3 direction = midPointParent.TransformDirection(new Vector3(0, 0, midPointLocalSpace.z));
            midPointVisualObject.localPosition = new Vector3(0, 0, -bowStringStretchLimit);
        }
    }

    private void HandleStringPushedBackToStart(Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z >= 0)
        {
            _strength = 0;
            midPointVisualObject.localPosition = Vector3.zero;
        }
    }
}