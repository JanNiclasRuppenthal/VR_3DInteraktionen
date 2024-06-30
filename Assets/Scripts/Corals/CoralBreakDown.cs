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
    GameObject coral1;
    GameObject coral2;
    GameObject coral3;
    GameObject wasteSpawner;
    // Start is called before the first frame update
    public void startColor()
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
        targetColor = new Color(0.5849f,0.5849f,0.5849f);
        grayscale = GameObject.Find("Grayscale");
        gameover = grayscale.GetComponent<PostProcessGray>().gameover;
        Lifetime = Random.Range(gameover/2,gameover);
        wasteSpawner =  GameObject.Find("WasteSpawner");
    }

    public float timeLeft = 1.0f;
    int cnt;
    private bool dead = false;

    // Update is called once per frame
    public void changeColor(float step)
    {
        if (Lifetime <= 0 && !dead){
            uniqueMaterial1.color = targetColor;
            uniqueMaterial2.color = targetColor;
            uniqueMaterial3.color = targetColor;
            grayscale.GetComponent<PostProcessGray>().aliveCorals -= 1;
            dead = true;
        }
        uniqueMaterial1.color = Color.Lerp(uniqueMaterial1.color, targetColor, step/Lifetime);
        uniqueMaterial2.color = Color.Lerp(uniqueMaterial2.color, targetColor, step/Lifetime);
        uniqueMaterial3.color = Color.Lerp(uniqueMaterial3.color, targetColor, step/Lifetime);
        cnt = wasteSpawner.GetComponent<spawnWaste>().cnt;
        if (cnt > 5){
            Lifetime -= 0.05f * wasteSpawner.GetComponent<spawnWaste>().cnt;
        }else{
            Lifetime += 0.05f * wasteSpawner.GetComponent<spawnWaste>().cnt;
        }
    }
}
