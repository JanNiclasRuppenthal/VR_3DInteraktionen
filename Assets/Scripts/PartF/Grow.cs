using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    [SerializeField] private float min = 0.4f;
    [SerializeField] private float max = 4f;
    [SerializeField] private float speed = 0.2f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
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
            return;
        }
    }
}
