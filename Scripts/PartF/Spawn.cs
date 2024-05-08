using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public int treecount = 1;
    public float minSize = 0.4f;
    private float startTime;
    private List<Vector2> trees = new List<Vector2>() { new Vector2(0, 0) };
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(startTime - Time.time) > 0.1)
        {
            if (treecount < 100)
            {
                Vector2 pos = new Vector2(Random.Range(-50.0f, 50.0f), Random.Range(-50.0f, 50.0f));
                if (isAcceptable(pos))
                {
                    GameObject go = Instantiate(prefab, new Vector3(pos.x, 0, pos.y), Quaternion.identity);
                    go.transform.localScale = new Vector3(minSize, minSize, minSize);
                    go.AddComponent<Grow>();
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
            if(Vector2.Distance(tree, xz) < 5)
            {
                return false;
            }
        }
        return true;
    }
}
