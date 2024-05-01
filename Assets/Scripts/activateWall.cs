using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateWall : MonoBehaviour
{
    public GameObject wall;
    bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            active = wall.activeSelf;
            wall.SetActive(!active);
        }
    }
}
