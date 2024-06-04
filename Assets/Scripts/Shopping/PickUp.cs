using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    private GameObject articles;
    [SerializeField]
    private float radius = 0.2f;
    [SerializeField]
    private GameObject HandL;
    [SerializeField]
    private GameObject HandR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        check(HandL);
        check(HandR);
    }
    private void check(GameObject hand)
    {
        Collider[] hitColliders = Physics.OverlapSphere(hand.transform.position, radius);
        foreach(var hitc in hitColliders)
        {
            if (hitc.transform.parent == articles.transform)
            {
                hitc.gameObject.SetActive(false);
            }
        }
    }
}
