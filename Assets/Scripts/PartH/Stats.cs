using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Stats : MonoBehaviour
{
    public GameObject currentBird;
    public int score = 0;
    public int cooldown = 0;
    public GameObject PanelScore;
    public GameObject PanelRaycast;
    private string scoreText = "";
    private string rayText="";
    public InputActionProperty raycastButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0)
        {
            cooldown = 0;
            rayText = "RayCast ready";
        }
        else
        {
            rayText = "RayCast in " + cooldown;
        }
        PanelRaycast.GetComponent<TextMeshPro>().SetText(rayText);
        scoreText = "Score " + score;
        PanelScore.GetComponent<TextMeshPro>().SetText(scoreText);
    }

    public void timer()
    {
        StartCoroutine(countdown());
    }

    IEnumerator countdown()
    {
        cooldown = 10;
        while (cooldown > 0)
        {
            yield return new WaitForSeconds(1f);
            cooldown -= 1;
        }

    }
}
