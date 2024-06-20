using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralScanTrash : MonoBehaviour
{

    private Renderer renderer;
 
    private Material uniqueMaterial;
    private float Lifetime = 50.0f;
    private Color targetColor;
    GameObject coral1;
    GameObject coral2;
    GameObject coral3;
    // Start is called before the first frame update
    void Start()
    {
        coral1 = this.gameObject.transform.GetChild(0).gameObject;
        coral2 = this.gameObject.transform.GetChild(1).gameObject;
        coral3 = this.gameObject.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Lifetime <= 0){
            Destroy(this.gameObject.GetComponent<CoralScanTrash>());
        }
    }

    public float timeLeft = 1.0f;
    public float timeLeft2 = 1.0f;
    void OnTriggerStay(Collider obj){
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (obj.gameObject.tag == "Waste")
        {
            timeLeft -= Time.deltaTime;  
            if (timeLeft <= 0) 
            {
                Lifetime = Lifetime - 1.75f + Vector3.Distance(obj.gameObject.transform.position, this.gameObject.transform.position);
                
                Debug.Log("Distance: " + Vector3.Distance(obj.gameObject.transform.position, this.gameObject.transform.position));
                coral1.GetComponent<CoralBreakDown>().Lifetime = Lifetime;
                coral2.GetComponent<CoralBreakDown>().Lifetime = Lifetime;
                coral3.GetComponent<CoralBreakDown>().Lifetime = Lifetime;
                coral1.GetComponent<CoralBreakDown>().timeLeft = timeLeft;
                coral2.GetComponent<CoralBreakDown>().timeLeft = timeLeft;
                coral3.GetComponent<CoralBreakDown>().timeLeft = timeLeft;
                timeLeft = 1.0f;
            }

        }
    }
}
