using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{

    [SerializeField] public List<Vector2> trees = new List<Vector2>()
    {
        new Vector2(0, 0),
        new Vector2(-40, 0),
        new Vector2(-20, 20),
        new Vector2(-20, -20),
        new Vector2(20, 0),
        new Vector2(20, 20),
        new Vector2(40, 0),
        new Vector2(-20, 0),
        new Vector2(40, 30),
        new Vector2(20, -20),
        new Vector2(40, -30)
    };
    
    public GameObject prefab;
    public int treecount = 11;
    public float minSize = 0.4f;
    private float startTime;
    private GameObject parent;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        parent = GameObject.Find("Trees");
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(startTime - Time.time) > 1.25f)
        {
            if (treecount < 11)
            {
                Vector2 pos = new Vector2(Random.Range(-45.0f, 45.0f), Random.Range(-45.0f, 45.0f));
                if (isAcceptable(pos))
                {
                    GameObject go = Instantiate(prefab, new Vector3(pos.x, 0, pos.y), Quaternion.identity);
                    go.transform.localScale = new Vector3(minSize, minSize, minSize);
                    go.AddComponent<Grow>();
                    go.transform.parent = parent.transform;
                    treecount += 1;
                    trees.Add(pos);
                }

            }

            startTime = Time.time;
        }
    }

    bool isAcceptable(Vector2 xz)
    {
        
        foreach (Vector2 tree in trees)
        {
            if(Vector2.Distance(tree, xz) < 7)
            {
                return false;
            }
        }
        return true;
    }
}
