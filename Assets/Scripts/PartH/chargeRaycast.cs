using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargeRaycast : MonoBehaviour
{
    public GameObject rayL;
    public GameObject conL;
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
        if (!conL.GetComponent<GrabbingLeftController>().isgrabbing)
        {
            rayL.SetActive(true);
        }
    }
}
