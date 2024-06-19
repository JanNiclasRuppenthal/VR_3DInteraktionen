using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralBreakDown : MonoBehaviour
{
    
    private Renderer renderer;
 
    private Material uniqueMaterial;
    public int Lifetime = 15;
    private Color targetColor;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        uniqueMaterial = renderer.material;
        targetColor = new Color(1.0f,1.0f,1.0f);
        
    }

    public float timeLeft2 = 1.0f;
    public float timeLeft = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (Lifetime <= 0){
            uniqueMaterial.color = targetColor;
            Destroy(this);
        }
        if (timeLeft <= 0){
            uniqueMaterial.color = Color.Lerp(uniqueMaterial.color, targetColor, Time.deltaTime / timeLeft2);
            timeLeft2 -= Time.deltaTime;
            timeLeft = 1.0f;
        }
    }
}
