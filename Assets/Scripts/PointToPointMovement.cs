using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PointToPointMovement : MonoBehaviour
{
    
    private float speed;
    private Vector3[] positions;
    private int nextIndex;
    private int startIndex;
    private Vector3 nextPosition;

    public bool infinite;
    

    public void setPositionIndex(Vector3[] positions, float speed)
    {
        this.positions = positions;
        this.speed = speed;
        
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

        startIndex = nextIndex;
        nextPosition = positions[nextIndex];
    }

    public void movement()
    {
        if (this.transform.position == nextPosition)
        {

            if (this.gameObject.name.Contains("Actor"))
            {
                if (infinite || nextIndex != startIndex)
                {
                    nextIndex = ++nextIndex % positions.Length;
                    nextPosition = positions[nextIndex];
                }
            }
            else if (this.gameObject.name.Contains("Camera"))
            {
                if (infinite || nextIndex != positions.Length-1)
                {
                    nextIndex = ++nextIndex % positions.Length;
                    nextPosition = positions[nextIndex];
                }
            }
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, nextPosition,
                speed * Time.deltaTime);
        }
    }

    public void setInfiniteStatus(bool infinite)
    {
        this.infinite = infinite;
    }
}
