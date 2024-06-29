using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallWaste : MonoBehaviour
{
    GameObject ground;
    float speed = 1f;
    RaycastHit hit;
    Ray downRay;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        float x = this.gameObject.GetComponent<BoxCollider>().bounds.size.x;
        float y = this.gameObject.GetComponent<BoxCollider>().bounds.size.y;
        float z = this.gameObject.GetComponent<BoxCollider>().bounds.size.z;
        float max = Mathf.Max(x,y,z);
        
        ground = GameObject.Find("Bottom");
        downRay = new Ray(transform.position, -Vector3.up);
        Physics.Raycast(downRay, out hit);
        target = new Vector3(hit.point.x, hit.point.y + max + 0.5f, hit.point.z);
        transform.rotation = Random.rotation;
    }

    float dist;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) > 0){
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
            
    }
}
