using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteStats : MonoBehaviour
{
    [SerializeField]
    int collected = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setCollected()
    {
        collected++;
        Debug.Log("Trash collected: " + collected);
    }
}
