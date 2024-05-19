using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbingLeftController : MonoBehaviour
{
    [SerializeField] private Transform bow;
    [SerializeField] private Transform bowString;
    [SerializeField] private GameObject rayInteractor;
    [SerializeField] private GameObject arrow;
    
    
    private XRGrabInteractable _interactableBow;
    private XRGrabInteractable _interactableBowString;

    private void Awake()
    {
        _interactableBow = bow.GetComponent<XRGrabInteractable>();
        _interactableBowString = bowString.GetComponent<XRGrabInteractable>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _interactableBow.selectEntered.AddListener(DeactivateRayAndArrow);
        _interactableBow.selectExited.AddListener(ActivateRayAndArrow);
        
        _interactableBowString.selectEntered.AddListener(DeactivateRayAndArrow);
        _interactableBowString.selectExited.AddListener(ActivateRayAndArrow);
    }

    private void ActivateRayAndArrow(SelectExitEventArgs arg0)
    {
        if (arg0.interactorObject.transform.name.Contains("Left"))
        {
            arrow.SetActive(true);
            rayInteractor.SetActive(true);
        }
    }

    private void DeactivateRayAndArrow(SelectEnterEventArgs arg0)
    {
        if (arg0.interactorObject.transform.name.Contains("Left"))
        {
            arrow.SetActive(false);
            rayInteractor.SetActive(false);
        }
    }
}
