using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private GameObject midPointVisual, arrowPrefab, arrowSpawnPoint;

    [SerializeField]
    private float arrowMaxSpeed = 50;

    [SerializeField] private Transform parentArrows;

    private List<GameObject> _listOfArrows;


    public void PrepareArrow()
    {
        midPointVisual.SetActive(true);
    }

    public void ReleaseArrow(float strength)
    {
        midPointVisual.SetActive(false);

        GameObject arrow = Instantiate(arrowPrefab);
        
        arrow.transform.parent = parentArrows;
        arrow.transform.position = arrowSpawnPoint.transform.position;
        arrow.transform.rotation = midPointVisual.transform.rotation;
        
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.AddForce(midPointVisual.transform.forward * strength * arrowMaxSpeed, ForceMode.Impulse);
        
        // _listOfArrows.Add(arrow);
        //
        // if (_listOfArrows.Count >= 10)
        // {
        //     GameObject tempArrow = _listOfArrows[0];
        //     Destroy(tempArrow);
        // }

    }
}