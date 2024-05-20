using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyThis());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator destroyThis()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
