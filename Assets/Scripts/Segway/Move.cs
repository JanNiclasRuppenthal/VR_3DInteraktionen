using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    public float rotation = 0f;
    [SerializeField]
    public float movement = 0f;
    float radiusTire = 0.4f;
    float radiusSegway = 0.55f;
    float circ;
    bool onGround = false;

    GameObject tireLeft;
    GameObject tireRight;

    void Start()
    {
        tireLeft = this.transform.GetChild(7).gameObject;
        Debug.Log(tireLeft.name);
        tireRight = this.transform.GetChild(8).gameObject;
        Debug.Log(tireRight.name);
        circ = 2.0f * Mathf.PI * radiusTire;
        Debug.Log("Circ"+ circ);
    }

    RaycastHit hit;
    float dist;
    Vector3 dir;

    void Update()
    {
        dist = 9;
        dir = new Vector3(0,-1,0);

        Debug.DrawRay(transform.position, dir * dist, Color.yellow);
        Physics.Raycast(transform.position,dir, out hit, dist, 1);
        if(hit.collider.gameObject.name == "StairsDown"){
            onGround = false;
            this.transform.position +=  -Vector3.up * 0.64f * 1.3f *  Time.deltaTime;
            this.transform.position += Vector3.forward  * 0.77f * 1.3f *  Time.deltaTime;
        }else if(hit.collider.gameObject.name == "StairsUp"){
            onGround = false;
            this.transform.position += Vector3.up * 0.64f * 1.3f * Time.deltaTime;
            this.transform.position += -Vector3.forward  * 0.77f * 1.3f * Time.deltaTime;
        }else if(hit.collider.gameObject.name == "Mall" && !(onGround)){
            onGround = true;
            this.transform.position = new Vector3(this.transform.position.x,hit.point.y+0.02f,this.transform.position.z);
        }
        
        if(movement > 0){
            if(hit.collider.gameObject.name == "Mall"){
                tireLeft.transform.Rotate(movement/circ * 360.0f *  Time.deltaTime, 0.0f, 0.0f);
                tireRight.transform.Rotate(movement/circ * 360.0f * Time.deltaTime, 0.0f, 0.0f);
                //this.transform.position += this.transform.forward * movement *  Time.deltaTime;
            }
        }else if(movement < 0){
            if(hit.collider.gameObject.name == "Mall"){
                tireLeft.transform.Rotate(movement/circ * 360.0f *  Time.deltaTime, 0.0f, 0.0f);
                tireRight.transform.Rotate(movement/circ * 360.0f * Time.deltaTime, 0.0f, 0.0f);
                //this.transform.position += -this.transform.forward * movement *  Time.deltaTime;
            }
        }else if(rotation < 0){
            if(hit.collider.gameObject.name == "Mall"){
                float tireRotation = Mathf.Abs(rotation * radiusSegway / radiusTire);
                tireLeft.transform.Rotate(-tireRotation *  Time.deltaTime, 0.0f, 0.0f);
                tireRight.transform.Rotate(tireRotation *  Time.deltaTime, 0.0f, 0.0f);
                //this.transform.Rotate(0.0f,-rotation *  Time.deltaTime, 0.0f);
            }
        }else if(rotation > 0){
            if(hit.collider.gameObject.name == "Mall"){
                float tireRotation = Mathf.Abs(rotation * radiusSegway / radiusTire);
                tireLeft.transform.Rotate(tireRotation *  Time.deltaTime, 0.0f, 0.0f);
                tireRight.transform.Rotate(-tireRotation *  Time.deltaTime, 0.0f, 0.0f);
                //this.transform.Rotate(0.0f,rotation *  Time.deltaTime, 0.0f);
            }
        }
    }
}
