using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmManager : MonoBehaviour
{
    public static SwarmManager SM;
    public GameObject[] AllFish { get => _allFish; }
    public Vector3 GoalPos => goalTransform.position;
    public float MinSpeed => minSpeed;
    public float MaxSpeed => maxSpeed;
    public float RotationSpeed => rotationSpeed;
    public float NeighbourDistance => neighbourDistance;
    
    [Header("Settings")]
    [SerializeField] private GameObject fishPrefab;
    [SerializeField] private int numFish = 100;
    [SerializeField] private Vector3 swimLimit = new Vector3(5, 5, 5);
    [SerializeField] private Transform goalTransform;
    
    [Header("Speed")] 
    [Range(0.0f, 5.0f)]
    [SerializeField] private float minSpeed;
    [Range(0.0f, 5.0f)]
    [SerializeField] private float maxSpeed;
    [Range(1.0f, 100.0f)]
    [SerializeField] private float neighbourDistance;
    [Range(1.0f, 5.0f)]
    [SerializeField] private float rotationSpeed;
    
    
    private GameObject[] _allFish;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _allFish = new GameObject[numFish];
        for (int index = 0; index < numFish; index++)
        {
            Vector3 startPos = this.transform.position + new Vector3(
                Random.Range(-swimLimit.x, swimLimit.x),
                Random.Range(-swimLimit.y, swimLimit.y),
                Random.Range(-swimLimit.z, swimLimit.z)
            );
            _allFish[index] = Instantiate(fishPrefab, startPos, Quaternion.identity);
        }

        SM = this;
    }
}