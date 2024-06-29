using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SwarmUnit : MonoBehaviour
{
    [Header("Obstacle Settings")]
    [SerializeField] private LayerMask obstacleMask;
    [SerializeField] private LayerMask cameraMask;
    [SerializeField] private Vector3[] directionsToCheckWhenAvoidingObstacles;
    
    private float _speed;
    private Vector3 _currentObstacleAvoidanceVector;
    private Vector3 _currentVelocity;
    
    
    private PostProcessGray _processGray;
    private float _gameOverTime;
    private float _lifeTime;
    public float LifeTime
    {
        get => _lifeTime;
        set => _lifeTime = value;
    }

    private spawnWaste _wasteSpawner;
    private GameObject _ground;

    // Start is called before the first frame update
    void Start()
    {
        _processGray = GameObject.Find("Grayscale").GetComponent<PostProcessGray>();
        _wasteSpawner = GameObject.Find("WasteSpawner").GetComponent<spawnWaste>();
        _speed = Random.Range(SwarmManager.SM.MinSpeed, SwarmManager.SM.MaxSpeed);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_processGray.aliveCorals <= _lifeTime)
        {
            this.transform.gameObject.SetActive(false);
            return;
        }
        else
        {
            if (Random.Range(0, 100) < 5)
            {
                _speed = Random.Range(SwarmManager.SM.MinSpeed, SwarmManager.SM.MaxSpeed);
            }
            if (Random.Range(0, 100) < 25)
            {
                ApplyRules();
            }
        
            Vector3 obstacleVector = CalculateObstacleVector() * 10;

            // transform.forward = obstacleVector;
            // this.transform.position += obstacleVector * speed * Time.deltaTime;
        
            Vector3 moveVector = obstacleVector;
			
			
            moveVector = Vector3.SmoothDamp(transform.forward, moveVector, ref _currentVelocity, 1);
            moveVector = moveVector.normalized * _speed;
            if (moveVector == Vector3.zero)
                moveVector = transform.forward;

            transform.forward = moveVector;
            transform.position += moveVector * Time.deltaTime;
        }
    }
    
    private Vector3 CalculateObstacleVector()
    {
        Vector3 obstacleVector = Vector3.zero;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2,
                obstacleMask) || Physics.Raycast(transform.position, transform.forward, out hit, 8,
                cameraMask))
        {
            obstacleVector = FindBestDirectionToAvoidObstacle();
        }
        else
        {
            _currentObstacleAvoidanceVector = Vector3.zero;
        }

        return obstacleVector;
    }

    private Vector3 FindBestDirectionToAvoidObstacle()
    {
        if (_currentObstacleAvoidanceVector != Vector3.zero)
        {
            RaycastHit hit;
            if (!Physics.Raycast(transform.position, transform.forward, out hit, 2,
                    obstacleMask) || !Physics.Raycast(transform.position, transform.forward, out hit, 8,
                    cameraMask))
            {
                return _currentObstacleAvoidanceVector;
            }
        }

        float maxDistance = int.MinValue;
        Vector3 selectedDirection = Vector3.zero;
        for (int i = 0; i < directionsToCheckWhenAvoidingObstacles.Length; i++)
        {

            RaycastHit hit;
            Vector3 currentDirection =
                transform.TransformDirection(directionsToCheckWhenAvoidingObstacles[i].normalized);
            if (Physics.Raycast(transform.position, currentDirection, out hit, 2,
                    obstacleMask) || Physics.Raycast(transform.position, transform.forward, out hit, 8,
                    cameraMask))
            {

                float currentDistance = (hit.point - transform.position).sqrMagnitude;
                if (currentDistance > maxDistance)
                {
                    maxDistance = currentDistance;
                    selectedDirection = currentDirection;
                }
            }
            else
            {
                selectedDirection = currentDirection;
                _currentObstacleAvoidanceVector = currentDirection.normalized;
                return selectedDirection.normalized;
            }
        }

        return selectedDirection.normalized;
    }

    private void ApplyRules()
    {
        GameObject[] gos;
        gos = SwarmManager.SM.AllFish;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if (go.activeSelf && go != this.gameObject)
            {
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);

                if (nDistance <= SwarmManager.SM.NeighbourDistance)
                {
                    vcentre += go.transform.position;
                    groupSize++;

                    if (nDistance < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    SwarmUnit anotherFlock = go.GetComponent<SwarmUnit>();
                    gSpeed = gSpeed + anotherFlock._speed;
                }
            }
        }

        if (groupSize > 0)
        {
            vcentre = vcentre / groupSize + (SwarmManager.SM.GoalPos - this.transform.position);
            _speed = gSpeed / groupSize;

            if (_speed > SwarmManager.SM.MaxSpeed)
            {
                _speed = SwarmManager.SM.MaxSpeed;
            }

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), SwarmManager.SM.RotationSpeed * Time.deltaTime);
            }
        }
        
    }
}
