using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    private GameObject bird;
    public GameObject GameStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bird = GameStats.GetComponent<Stats>().currentBird;
        if (!bird.name.StartsWith("Game"))
        {
            this.transform.LookAt(bird.transform.position);
        }
    }
}
