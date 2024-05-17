using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargeRaycast : MonoBehaviour
{
    public GameObject rayL;
    public GameObject rayR;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void charge()
    {
        StartCoroutine(chargeRay());
    }

    IEnumerator chargeRay()
    {
        yield return new WaitForSeconds(10f);
        rayL.SetActive(true);
        rayR.SetActive(true);
    }
}
