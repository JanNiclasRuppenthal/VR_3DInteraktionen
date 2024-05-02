using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateWall : MonoBehaviour
{
    public GameObject wall;
    bool active = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            active = wall.activeSelf;
            wall.SetActive(!active);
        }
    }
}
