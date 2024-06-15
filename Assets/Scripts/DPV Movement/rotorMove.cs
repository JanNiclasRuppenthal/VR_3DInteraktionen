using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotorMove : MonoBehaviour
{
    [SerializeField]
    private GameObject rotor;
    private float movement = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movement > 0 || movement < 0)
        {
            rotor.transform.Rotate(new Vector3(0f, 0f, movement* 22.5f * Time.deltaTime), Space.Self);
        }
    }

    public void SetMovement(float newM)
    {
        movement = newM;
    }
}
