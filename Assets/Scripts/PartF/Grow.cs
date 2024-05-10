using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class Grow : MonoBehaviour
{
    private float max = 4f;
    private float speed = 0.05f;
    private GameObject spawnManager;
    private BirdActivity sparrowScript;
    private Spawn spawnScript;
    private MeshRenderer renderer;
    private ParticleSystem fallingLeaves;
    private ParticleSystem explosion;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager");
        spawnScript = spawnManager.GetComponent<Spawn>();
        
        sparrowScript = GameObject.Find("Sparrow").GetComponent<BirdActivity>();

        renderer = this.gameObject.GetComponent<MeshRenderer>();
        
        fallingLeaves = this.transform.GetChild(0).GetComponent<ParticleSystem>();
        fallingLeaves.gameObject.SetActive(true);
        
        explosion = this.transform.GetChild(1).GetComponent<ParticleSystem>();
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
            fallingLeaves.gameObject.SetActive(false);
            renderer.enabled = false;
            explosion.gameObject.transform.localScale = newScale;
            explosion.gameObject.SetActive(true);
            explosion.Play();

            StartCoroutine(test());
            return;
        }
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(0.4f);
        spawnScript.trees.RemoveAt(0);
        spawnScript.treecount -= 1;
        Destroy(this.gameObject);
    }
    
}
