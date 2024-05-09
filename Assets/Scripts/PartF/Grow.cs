using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    private float max = 4f;
    private float speed = 0.05f;

    private GameObject spawnManager;
    private GameObject fallingLeaves;
    private Spawn spawnScript;
    
    
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager");
        spawnScript = spawnManager.GetComponent<Spawn>();
        fallingLeaves = this.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float x = this.transform.localScale.x + speed * Time.deltaTime;
        float y = this.transform.localScale.y + speed  * Time.deltaTime;
        float z = this.transform.localScale.z + speed  * Time.deltaTime;

        Vector3 newScale = new Vector3(x, y, z);

        this.transform.localScale = newScale;
        fallingLeaves.transform.localScale = newScale;


        if (x >= max)
        {
            spawnScript.trees.RemoveAt(0);
            spawnScript.treecount -= 1;
            Destroy(this.gameObject); 
            return;
        }
    }
}
