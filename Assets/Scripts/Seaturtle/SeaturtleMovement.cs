using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaturtleMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject turtle;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float turnspeed = 20f;
    private float forwardTime = 10f;
    private float angle = 0f;
    private float fullAngle = 0f;
    private bool turnRight = false;
    private bool pause = true;
    void Start()
    {
        StartCoroutine(ForwardMoveStart());
    }

    private void Update()
    {
        turtle.transform.position += turtle.transform.right * speed * Time.deltaTime;
        if (pause)
        {
            angle = 0f;
            return;
        }
        angle = turnspeed * speed * Time.deltaTime;

        if (turnRight)
        {
            turtle.transform.Rotate(Vector3.up, angle);
            //turtle.transform.rotation = Quaternion.RotateTowards(turtle.transform.rotation, Quaternion.Euler(0, 180, 0), angle);
        }
        else
        {
            turtle.transform.Rotate(Vector3.up, -angle);
            //turtle.transform.rotation = Quaternion.RotateTowards(turtle.transform.rotation, Quaternion.Euler(0, -180, 0), angle);
        }

        fullAngle += angle;
        //Debug.Log("fullangle:"+fullAngle);
        if (fullAngle >= 180.0f)
        {
            //Debug.Log("Switch");
            fullAngle = 0f;
            pause = true;
            StartCoroutine(ForwardMove());
        }

    }
    IEnumerator ForwardMoveStart()
    {
        yield return new WaitForSeconds(forwardTime);
        pause = false;
        turnRight = !turnRight;
    }
    IEnumerator ForwardMove()
    {
        yield return new WaitForSeconds(2*forwardTime);
        pause = false;
        turnRight = !turnRight;
    }
}
