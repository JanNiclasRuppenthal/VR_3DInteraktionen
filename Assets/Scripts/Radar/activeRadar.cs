using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class activeRadar : MonoBehaviour
{
    [SerializeField] private GameObject radar;
    [SerializeField] private XRBaseInteractor lInteractor;
    [SerializeField] private XRBaseInteractor rInteractor;
    [SerializeField] private GameObject dpv;

    [SerializeField] private XRRayInteractor rayLineLeft;
    [SerializeField] private XRRayInteractor rayLineRight;
    
    // Update is called once per frame
    void Update()
    {
        if (rConGrab())
        {
            rayLineRight.maxRaycastDistance = 0;
        }
        else if(dpv.activeSelf)
        {
            rayLineRight.maxRaycastDistance = 0.5f;
        }
        
        if (lConGrab())
        {
            radar.SetActive(false);
            rayLineLeft.maxRaycastDistance = 0f;
        }
        else if (!radar.activeSelf && dpv.activeSelf)
        {
            radar.SetActive(true);
            rayLineLeft.maxRaycastDistance = 0.5f;
        }
    }
    private bool lConGrab()
    {
        return lInteractor.isSelectActive;
    }
    
    private bool rConGrab()
    {
        return rInteractor.isSelectActive;
    }
}
