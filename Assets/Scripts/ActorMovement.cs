using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMovement : MonoBehaviour
{
    public float speed = 1.5f;
    
    private PointToPointMovement pMovement;
    private Vector3[] positions = new [] 
    {
        new Vector3(-4.1f, -2.02f, 8.546f),
        new Vector3(1.92f, -0.82f, 4.726f),
        new Vector3(1.92f, -0.82f, 2.025f),
        new Vector3(-4.1f, -2.02f, 4.696f)
    };

    private bool areMoving;
    
    // Start is called before the first frame update
    void Start()
    {
        pMovement = this.GetComponent<PointToPointMovement>();
        pMovement.setPositionIndex(positions, this.speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            areMoving = !areMoving;
            pMovement.setInfiniteStatus(true);
        }


        if (areMoving)
        {
            pMovement.movement();
        }
    }
}
