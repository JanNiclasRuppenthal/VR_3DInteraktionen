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

    // [SerializeField] private LineRenderer rayLineLeft;
    // [SerializeField] private LineRenderer rayLineRight;
    
    // Update is called once per frame
    void Update()
    {

        // if (rConGrab())
        // {
        //     rayLineRight.transform.gameObject.SetActive(false);
        // }
        // else if(dpv.activeSelf)
        // {
        //     rayLineRight.transform.gameObject.SetActive(true);
        // }
        
        if (lConGrab())
        {
            radar.SetActive(false);
            // rayLineLeft.transform.gameObject.SetActive(false);
        }
        else if (!radar.activeSelf && dpv.activeSelf)
        {
            radar.SetActive(true);
            // rayLineLeft.transform.gameObject.SetActive(true);
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
