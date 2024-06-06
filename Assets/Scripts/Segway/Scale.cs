using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{

    
    public GameObject start;
    public GameObject end;
    private Vector3 initScale;
    // Start is called before the first frame update
    void Start()
    {
        
        initScale = transform.localScale;
        UpdateScale();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScale();
    }

    void UpdateScale(){
        float dist = Vector3.Distance(start.transform.position, end.transform.position);
        transform.localScale = new Vector3(initScale.x,dist/2.85f, initScale.z);
        Vector3 middle = (start.transform.position+end.transform.position)/2f;
        transform.position = middle;
        Debug.Log(middle);

        Vector3 rotation = (end.transform.position - start.transform.position);
        transform.up = rotation;
    }
}
