using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralScanTrash : MonoBehaviour
{

    private Renderer renderer;
 
    private Material uniqueMaterial;
    private int Lifetime = 15;
    private Color targetColor;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
 
        uniqueMaterial = renderer.material;
        targetColor = new Color(1.0f,1.0f,1.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Lifetime <= 0){
            uniqueMaterial.color = targetColor;
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
                timeLeft = 1.0f;
                uniqueMaterial.color = Color.Lerp(uniqueMaterial.color, targetColor, Time.deltaTime / timeLeft2);
                timeLeft2 -= Time.deltaTime;
                
            }

            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Lifetime: " + Lifetime);
        }
    }
}
