using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralScanTrash : MonoBehaviour
{

    private Renderer renderer;
 
    private Material uniqueMaterial;
    private float Lifetime = 50.0f;
    private Color targetColor;
    private GameObject grayscale;
    private float gameover;
    private float looseLife;
    public float timeLeft = 1.0f;
    public float timeLeft2 = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        grayscale = GameObject.Find("Grayscale");
        gameover = grayscale.GetComponent<PostProcessGray>().gameover;
        looseLife = Lifetime/gameover;
    }

    // Update is called once per frame
    void Update()
    {
        if (Lifetime <= 0){
            Destroy(this.gameObject.GetComponent<CoralScanTrash>());
        }
        timeLeft2 -= Time.deltaTime;  
        if (timeLeft2 <= 0){
            Lifetime -= looseLife;
            this.gameObject.GetComponent<CoralBreakDown>().Lifetime = Lifetime;
            this.gameObject.GetComponent<CoralBreakDown>().timeLeft = timeLeft2;
            
            timeLeft2 = 1.0f;
            //Debug.Log("Loose: " + looseLife + " Lifetime: " + Lifetime + " GameOver: " + gameover);
        }
    }

    void OnTriggerStay(Collider obj){
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (obj.gameObject.tag == "Waste")
        {
            timeLeft -= Time.deltaTime;  
            if (timeLeft <= 0) 
            {
                Lifetime = Lifetime - (2.0f - Vector3.Distance(obj.gameObject.transform.position, this.gameObject.transform.position))*looseLife*5.0f;
                
                Debug.Log("Distance: " + Vector3.Distance(obj.gameObject.transform.position, this.gameObject.transform.position));
                this.gameObject.GetComponent<CoralBreakDown>().Lifetime = Lifetime;
                this.gameObject.GetComponent<CoralBreakDown>().timeLeft = timeLeft;
                timeLeft = 1.0f;
            }

        }
    }
}
