using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralShellBreakDown : Coral
{
    
    private Renderer renderer1;
    private Renderer renderer2;
    private Renderer renderer3;
 
    private Material uniqueMaterial1;
    private Material uniqueMaterial2;
    private Material uniqueMaterial3;
    private Material uniqueMaterial4;
    private Material uniqueMaterial5;
    private Material uniqueMaterial6;
    public float Lifetime = 50.0f;
    private Color targetColor;
    private PostProcessGray grayscale;
    private float gameover;
    GameObject coral1;
    GameObject coral2;
    GameObject coral3;
    spawnWaste wasteSpawner;
    // Start is called before the first frame update
    public override void startColor()
    {
        coral1 = this.gameObject.transform.GetChild(0).gameObject;
        coral2 = this.gameObject.transform.GetChild(1).gameObject;
        coral3 = this.gameObject.transform.GetChild(2).gameObject;
        renderer1 = coral1.GetComponent<Renderer>();
        renderer2 = coral2.GetComponent<Renderer>();
        renderer3 = coral3.GetComponent<Renderer>();
        uniqueMaterial1 = renderer1.materials[0];
        uniqueMaterial2 = renderer2.materials[0];
        uniqueMaterial3 = renderer3.materials[0];
        uniqueMaterial4 = renderer1.materials[1];
        uniqueMaterial5 = renderer2.materials[1];
        uniqueMaterial6 = renderer3.materials[1];
        targetColor = new Color(1.0f,1.0f,1.0f);
        grayscale = GameObject.Find("Grayscale").GetComponent<PostProcessGray>();
        gameover = grayscale.gameover;
        Lifetime = Random.Range(gameover/2,gameover);
        wasteSpawner =  GameObject.Find("WasteSpawner").GetComponent<spawnWaste>();
    }

    public float timeLeft = 1.0f;
    int cnt;
    private bool dead = false;

    // Update is called once per frame
    public override void changeColor(float step)
    {
        if (Lifetime <= 0 && !dead){
            uniqueMaterial1.color = targetColor;
            uniqueMaterial2.color = targetColor;
            uniqueMaterial3.color = targetColor;
            uniqueMaterial4.color = targetColor;
            uniqueMaterial5.color = targetColor;
            uniqueMaterial6.color = targetColor;
            grayscale.aliveCorals -= 1;
            dead = true;
        }
        cnt = wasteSpawner.cnt;
        if (cnt > 5){
            Lifetime -= 0.5f * wasteSpawner.cnt;
            uniqueMaterial1.color = Color.Lerp(uniqueMaterial1.color, targetColor, step/Lifetime);
            uniqueMaterial2.color = Color.Lerp(uniqueMaterial2.color, targetColor, step/Lifetime);
            uniqueMaterial3.color = Color.Lerp(uniqueMaterial3.color, targetColor, step/Lifetime);
            uniqueMaterial4.color = Color.Lerp(uniqueMaterial4.color, targetColor, step/Lifetime);
            uniqueMaterial5.color = Color.Lerp(uniqueMaterial5.color, targetColor, step/Lifetime);
            uniqueMaterial6.color = Color.Lerp(uniqueMaterial6.color, targetColor, step/Lifetime);
        }else{
            Lifetime += 0.05f * wasteSpawner.cnt;
        }
    }
}
