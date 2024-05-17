using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnPartH : MonoBehaviour
{
    public List<GameObject> trees;
    public int maxTrees;
    public List<GameObject> treeroots;

    public GameObject oakTreePrefab;
    public GameObject oakTreerootPrefab;
    public float minSize = 0.4f;
    private float _startTime;
    private GameObject _parent;
    private GameObject _pRoots;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
        _parent = GameObject.Find("Trees");
        _pRoots = GameObject.Find("Treeroots");
        _player = GameObject.Find("XR Origin");
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(_startTime - Time.time) > 3f)
        {
            if (trees.Count < maxTrees)
            {
                Vector2 pos = new Vector2(Random.Range(-32.0f, 32.0f), Random.Range(-30.0f, 35.0f));
                if (isAcceptable(pos))
                {
                    GameObject go = Instantiate(oakTreePrefab, new Vector3(pos.x, 0, pos.y), Quaternion.identity);
                    go.transform.localScale = new Vector3(minSize, minSize, minSize);
                    go.AddComponent<GrowPartH>();
                    go.transform.parent = _parent.transform;
                    trees.Add(go);
                    GameObject root = Instantiate(oakTreerootPrefab, new Vector3(pos.x, 0, pos.y), Quaternion.identity);
                    root.transform.parent = _pRoots.transform;
                    treeroots.Add(root);
                }

            }
            _startTime = Time.time;
        }
    }

    bool isAcceptable(Vector2 xz)
    {
        foreach (GameObject tree in trees)
        {
            if (Vector2.Distance(new Vector2(tree.transform.position.x, tree.transform.position.z), xz) <= 10f 
                || Vector2.Distance(new Vector2(_player.transform.position.x, _player.transform.position.z), xz) <= 10f)
            {
                return false;
            }
        }
        return true;
    }
}
