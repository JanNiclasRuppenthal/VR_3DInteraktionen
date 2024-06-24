using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class activeRadar : MonoBehaviour
{
    [SerializeField] private GameObject radar;
    [SerializeField] private XRBaseInteractor lInteractor;
    [SerializeField] private GameObject dpv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lConGrab())
        {
            radar.SetActive(false);
        }
        else if (!radar.activeSelf && dpv.activeSelf)
        {
            radar.SetActive(true);
        }
    }
    private bool lConGrab()
    {
        return lInteractor.isSelectActive;

    }
}