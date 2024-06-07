using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPosHandle : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private GameObject ConL;
    [SerializeField]
    private GameObject ConR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = ConR.transform.position - ConL.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation *= Quaternion.Euler(0, 90, 0);
        obj.transform.rotation = rotation;
        Vector3 mid = (ConR.transform.position + ConL.transform.position) / 2;
        obj.transform.position = mid;
    }
}
