using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] private float speed; 
    
    private Vector3[] positions = new []
    {
        new Vector3(-4.1f, -2.02f, 8.546f),
        new Vector3(1.92f, -0.82f, 4.726f),
        new Vector3(1.92f, -0.82f, 2.025f),
        new Vector3(-4.1f, -2.02f, 4.696f)
    };
    private int nextIndex;
    private Vector3 nextPosition;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        nextIndex = -1;
        for (int index = 0; index < positions.Length; index++)
        {
            if (this.transform.position == positions[index])
            {
                nextIndex = index;
                break;
            }
        }

        if (nextIndex == -1)
        {
            Debug.LogWarning("Did not update nextIndex! Maybe wrong position of GameObject?");
        }
        
        nextPosition = positions[nextIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position == nextPosition)
        {
            nextIndex = ++nextIndex % positions.Length;
            nextPosition = positions[nextIndex];
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, nextPosition,
                    speed * Time.deltaTime);
        }
    }
}
