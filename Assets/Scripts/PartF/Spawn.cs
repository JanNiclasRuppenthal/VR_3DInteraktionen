using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    public List<GameObject> trees;
    public int maxTrees;
    
    public GameObject oakTreePrefab;
    public float minSize = 0.4f;
    private float _startTime;
    private GameObject _parent;
    
    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
        _parent = GameObject.Find("Trees");
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(_startTime - Time.time) > 3f)
        {
            if (trees.Count < maxTrees)
            {
                Vector2 pos = new Vector2(Random.Range(-45.0f, 45.0f), Random.Range(-45.0f, 45.0f));
                if (isAcceptable(pos))
                {
                    GameObject go = Instantiate(oakTreePrefab, new Vector3(pos.x, 0, pos.y), Quaternion.identity);
                    go.transform.localScale = new Vector3(minSize, minSize, minSize);
                    go.AddComponent<Grow>();
                    go.transform.parent = _parent.transform;
                    trees.Add(go);
                }

            }
            _startTime = Time.time;
        }
    }

    bool isAcceptable(Vector2 xz)
    {
        foreach (GameObject tree in trees)
        {
            if(Vector2.Distance(new Vector2(tree.transform.position.x, tree.transform.position.z), xz) <= 10f)
            {
                return false;
            }
        }
        return true;
    }
}
