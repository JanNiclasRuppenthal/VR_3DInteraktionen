using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{

    public float speed;

    [SerializeField] private GameObject[] partsOfAmesRoom;
    [SerializeField] private PointToPointMovement[] actors;
    
    private PointToPointMovement pMovement;
    private Vector3[] positions = new[]
    {
        new Vector3(0, 0, 0),
        new Vector3(0, 0, -7.5f)
    };

    private CameraBirdsEyeMovement birdsEyeMovement;
    private Vector3 centerOfRoom = new Vector3(0, 0, 3.5f);

    private bool isMoving = false;
    private bool finishedMoving = false;
    private bool isRotating = false;
    private bool finishedRotating = false;
    
    // Start is called before the first frame update
    void Start()
    {
        pMovement = this.GetComponent<PointToPointMovement>();
        pMovement.setPositionIndex(positions, speed);

        birdsEyeMovement = this.GetComponent<CameraBirdsEyeMovement>();
        birdsEyeMovement.initializeBirdEye(centerOfRoom, speed*4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isMoving && !finishedMoving)
            {
                isMoving = false;
            }
            else if ( !isMoving && !finishedMoving)
            {
                isMoving = true;
            }
            
            
            if (finishedMoving && !finishedRotating && isRotating)
            {
                isRotating = false;
            }
            else if (finishedMoving && !finishedRotating && !isRotating)
            {
                isRotating = true;
            }
            
            
            if (partsOfAmesRoom[0].activeSelf)
            {
                this.setPartsOfAmesRoomActiveOrInacative(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            this.setPartsOfAmesRoomActiveOrInacative(true);
            this.transform.position = new Vector3(0, 0, 0);
            this.transform.rotation = new Quaternion(0f, 0f,0f, 0f);
            
            for (int index = 0; index < actors.Length; index++)
            {
                actors[index].setInfiniteStatus(true);
            }

            isMoving = false;
            isRotating = false;

            finishedMoving = false;
            finishedRotating = false;
        }


        if (isMoving && this.transform.position == positions[positions.Length - 1])
        {
            isMoving = false;
            isRotating = true;
            finishedMoving = true;
        }
        else if (isRotating && this.transform.rotation.x > 0.55f)
        {
            finishedRotating = true;

            for (int index = 0; index < actors.Length; index++)
            {
                actors[index].setInfiniteStatus(false);
            }
        }
        else if (isMoving && !isRotating)
        {
            pMovement.movement();
            
        }
        else if (isRotating)
        {
            birdsEyeMovement.movement();
        }
    }


    private void setPartsOfAmesRoomActiveOrInacative(bool active)
    {
        for (int index = 0; index < partsOfAmesRoom.Length; index++)
        {
            partsOfAmesRoom[index].SetActive(active);
        }
    }
}
