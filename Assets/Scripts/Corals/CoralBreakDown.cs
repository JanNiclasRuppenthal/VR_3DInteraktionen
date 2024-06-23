using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralBreakDown : MonoBehaviour
{
    
    private Renderer renderer1;
    private Renderer renderer2;
    private Renderer renderer3;
 
    private Material uniqueMaterial1;
    private Material uniqueMaterial2;
    private Material uniqueMaterial3;
    public float Lifetime = 50.0f;
    private Color targetColor;
    private GameObject grayscale;
    private float gameover;
    private float looseLife;
    GameObject coral1;
    GameObject coral2;
    GameObject coral3;
    // Start is called before the first frame update
    void Start()
    {
        coral1 = this.gameObject.transform.GetChild(0).gameObject;
        coral2 = this.gameObject.transform.GetChild(1).gameObject;
        coral3 = this.gameObject.transform.GetChild(2).gameObject;
        renderer1 = coral1.GetComponent<Renderer>();
        renderer2 = coral2.GetComponent<Renderer>();
        renderer3 = coral3.GetComponent<Renderer>();
        uniqueMaterial1 = renderer1.material;
        uniqueMaterial2 = renderer2.material;
        uniqueMaterial3 = renderer3.material;
        targetColor = new Color(1.0f,1.0f,1.0f);
        grayscale = GameObject.Find("Grayscale");
        gameover = grayscale.GetComponent<PostProcessGray>().gameover;
        looseLife = Lifetime/gameover;

        
    }


    public float timeLeft2 = 1.0f;
    public float timeLeft = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (Lifetime <= 0){
            uniqueMaterial1.color = targetColor;
            uniqueMaterial2.color = targetColor;
            uniqueMaterial3.color = targetColor;
            grayscale.GetComponent<PostProcessGray>().aliveCorals -= 1;
            Destroy(this.gameObject.GetComponent<CoralBreakDown>());
        }
        if (timeLeft <= 0){
            //Debug.Log(Time.deltaTime);
            uniqueMaterial1.color = Color.Lerp(uniqueMaterial1.color, targetColor, looseLife * Time.deltaTime);
            uniqueMaterial2.color = Color.Lerp(uniqueMaterial2.color, targetColor, looseLife * Time.deltaTime);
            uniqueMaterial3.color = Color.Lerp(uniqueMaterial3.color, targetColor, looseLife * Time.deltaTime);
            timeLeft = 1.0f;
        }
    }
}
