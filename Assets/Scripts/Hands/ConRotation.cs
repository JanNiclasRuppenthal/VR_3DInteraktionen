using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConRotation : MonoBehaviour
{
    [SerializeField]
    private Transform locomotion;
    [SerializeField]
    private Transform lCon;
    [SerializeField]
    private Transform rCon;
    [SerializeField]
    private GameObject segway;
    private readonly float _baseRotation = 45f;
    private readonly float _maxRotation = 45f;
    private readonly float _deadzone = 0.1f;
    private readonly float _times = 2f;
    private float _rotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 mid = (lCon.position + rCon.position)/2;
        //Debug.Log(mid);
        Vector3 relativeMid = locomotion.InverseTransformPoint(mid);
        if (Mathf.Abs(relativeMid.x) > _deadzone)
        {
            if (relativeMid.x < 0)
            {
                relativeMid.x += _deadzone;
                _rotation = -(Mathf.Pow(_baseRotation * relativeMid.x, _times));
            }
            else
            {
                relativeMid.x -= _deadzone;
                _rotation = Mathf.Pow(_baseRotation * relativeMid.x, _times);
            }
            _rotation = Mathf.Clamp(_rotation, -_maxRotation, _maxRotation);
            locomotion.Rotate(0, _rotation * Time.deltaTime, 0);
            segway.GetComponent<Move>().rotation = _rotation;
        }
        else
        {
            segway.GetComponent<Move>().rotation = 0f;
        }
    }
}