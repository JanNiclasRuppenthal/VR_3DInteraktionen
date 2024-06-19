using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralScanTrash : MonoBehaviour
{

    private Renderer renderer;
 
    private Material uniqueMaterial;
    private int Lifetime = 15;
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
            Destroy(this);
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
                Lifetime = Lifetime - 1;
                coral1.GetComponent<CoralBreakDown>().Lifetime = Lifetime;
                coral2.GetComponent<CoralBreakDown>().Lifetime = Lifetime;
                coral3.GetComponent<CoralBreakDown>().Lifetime = Lifetime;
                coral1.GetComponent<CoralBreakDown>().timeLeft = timeLeft;
                coral2.GetComponent<CoralBreakDown>().timeLeft = timeLeft;
                coral3.GetComponent<CoralBreakDown>().timeLeft = timeLeft;
                timeLeft = 1.0f;
            }

            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Lifetime: " + Lifetime);
        }
    }
}
