using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallWaste : MonoBehaviour
{
    GameObject ground;
    float speed = 1.0f;
    RaycastHit hit;
    Ray downRay;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.Find("Bottom");
        downRay = new Ray(transform.position, -Vector3.up);
        Physics.Raycast(downRay, out hit);
        target = new Vector3(hit.point.x, hit.point.y + 0.2f, hit.point.z);
        transform.rotation = Random.rotation;
    }

    float dist;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) <= 0){
            Destroy(transform.GetComponent<fallWaste>());
        }else{
            
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
            
    }
}
