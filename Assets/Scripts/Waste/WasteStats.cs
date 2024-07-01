using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteStats : MonoBehaviour
{
    [SerializeField]
    int collected = 0;
    
    public void setCollected()
    {
        collected++;
        Debug.Log("Trash collected: " + collected);
    }
}
