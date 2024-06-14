using UnityEngine;
using UnityEngine.Serialization;

namespace SwarmBehaviour
{
    public class Swarm : MonoBehaviour
    {
        [Header("Spawn Setup")]
        [SerializeField] private SwarmUnit swarmUnitPrefab;
        [SerializeField] private int swarmSize;
        [SerializeField] private Vector3 spawnBounds;

        [Header("Speed Setup")]
        [Range(0, 10)]
        [SerializeField] private float minSpeed;
        public float MinSpeed => minSpeed;
        [Range(0, 10)]
        [SerializeField] private float maxSpeed;
        public float MaxSpeed => maxSpeed;
    
        
        [Header("Detection Distances")]
        [Range(0, 10)]
        [SerializeField] private float cohesionDistance;
        public float CohesionDistance => cohesionDistance;

        [Range(0, 10)]
        [SerializeField] private float avoidanceDistance;
        public float AvoidanceDistance => avoidanceDistance;

        [Range(0, 10)]
        [SerializeField] private float alignmentDistance;
        public float AlignmentDistance => alignmentDistance;
        
        [Range(0, 100)]
        [SerializeField] private float boundsDistance;
        public float BoundsDistance => boundsDistance;

        [Range(0, 10)]
        [SerializeField] private float obstacleDistance;
        public float ObstacleDistance => obstacleDistance;
        
        
        [Header("Behaviour Weights")]
        [Range(0, 10)]
        [SerializeField] private float cohesionWeight;
        public float CohesionWeight => cohesionWeight;

        [Range(0, 10)]
        [SerializeField] private float avoidanceWeight;
        public float AvoidanceWeight => avoidanceWeight;

        [Range(0, 10)]
        [SerializeField] private float alignmentWeight;
        public float AlignmentWeight => alignmentWeight;
        
        [Range(0, 100)]
        [SerializeField] private float obstacleWeight;
        public float ObstacleWeight => obstacleWeight;
        
        [Range(0, 10)]
        [SerializeField] private float boundsWeight;
        public float BoundsWeight => boundsWeight;


        public SwarmUnit[] AllUnits { get; set; }
    
        // Start is called before the first frame update
        void Start()
        {
            GenerateUnits();
        }
    
        // Update is called once per frame
        void Update()
        {
            for (int index = 0; index < swarmSize; index++)
            {
                AllUnits[index].MoveUnit();
            }
        }

        private void GenerateUnits()
        {
            AllUnits = new SwarmUnit[swarmSize];
            for (int index = 0; index < swarmSize; index++)
            {
                Vector3 randomVector = UnityEngine.Random.insideUnitSphere;
                randomVector = new Vector3(randomVector.x * spawnBounds.x, randomVector.y * spawnBounds.y,
                    randomVector.z * spawnBounds.z);
                Vector3 spawnPosition = transform.position + randomVector;
                Quaternion rotation = Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0);
                AllUnits[index] = Instantiate(swarmUnitPrefab, spawnPosition, rotation);
                AllUnits[index].AssignSwarm(this);
                AllUnits[index].InitializeSpeed(UnityEngine.Random.Range(minSpeed, maxSpeed));
            }
        }

    }
}
