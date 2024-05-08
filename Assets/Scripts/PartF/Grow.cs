using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    [SerializeField] private float min = 0.4f;
    [SerializeField] private float max = 1f;
    [SerializeField] private float speed = 0.2f;

    private GameObject spawnManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager");
    }

    // Update is called once per frame
    void Update()
    {
        float x = this.transform.localScale.x + speed * Time.deltaTime;
        float y = this.transform.localScale.y + speed  * Time.deltaTime;
        float z = this.transform.localScale.z + speed  * Time.deltaTime;
        
        this.transform.localScale = new Vector3(x, y, z);


        if (x >= max)
        {
            this.gameObject.SetActive(false);
            spawnManager.GetComponent<Spawn>().treecount -= 1;
            spawnManager.GetComponent<Spawn>().trees.RemoveAt(0);
            Destroy(this.gameObject);
            return;
        }
    }
}
