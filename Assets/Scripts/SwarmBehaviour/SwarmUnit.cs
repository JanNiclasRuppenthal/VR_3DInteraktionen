using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace SwarmBehaviour
{
	public class SwarmUnit : MonoBehaviour
	{
		[SerializeField] private float fovAngle;
		[SerializeField] private float smoothDamp;
		[SerializeField] private LayerMask obstacleMask;
		[SerializeField] private Vector3[] directionsToCheckWhenAvoidingObstacles;

		private List<SwarmUnit> _cohesionNeighbours = new List<SwarmUnit>();
		private List<SwarmUnit> _avoidanceNeighbours = new List<SwarmUnit>();
		private List<SwarmUnit> _aligementNeighbours = new List<SwarmUnit>();
		private Swarm _assignedSwarm;
		private Vector3 _currentVelocity;
		private Vector3 _currentObstacleAvoidanceVector;
		private float _speed;

		public Transform MyTransform { get; set; }

		private void Awake()
		{
			MyTransform = transform;
		}

		public void AssignSwarm(Swarm swarm)
		{
			_assignedSwarm = swarm;
		}

		public void InitializeSpeed(float speed)
		{
			this._speed = speed;
		}

		public void MoveUnit()
		{
			FindNeighbours();
			CalculateSpeed();

			Vector3 cohesionVector = CalculateCohesionVector() * _assignedSwarm.CohesionWeight;
			Vector3 avoidanceVector = CalculateAvoidanceVector() * _assignedSwarm.AvoidanceWeight;
			Vector3 aligementVector = CalculateAligementVector() * _assignedSwarm.AlignmentWeight;
			Vector3 boundsVector = CalculateBoundsVector() * _assignedSwarm.BoundsWeight;
			Vector3 obstacleVector = CalculateObstacleVector() * _assignedSwarm.ObstacleWeight;

			Vector3 moveVector = cohesionVector + avoidanceVector + aligementVector + boundsVector + obstacleVector;
			moveVector = Vector3.SmoothDamp(MyTransform.forward, moveVector, ref _currentVelocity, smoothDamp);
			moveVector = moveVector.normalized * _speed;
			if (moveVector == Vector3.zero)
				moveVector = transform.forward;

			MyTransform.forward = moveVector;
			MyTransform.position += moveVector * Time.deltaTime;
		}



		private void FindNeighbours()
		{
			_cohesionNeighbours.Clear();
			_avoidanceNeighbours.Clear();
			_aligementNeighbours.Clear();
			SwarmUnit[] allUnits = _assignedSwarm.AllUnits;
			for (int i = 0; i < allUnits.Length; i++)
			{
				SwarmUnit currentUnit = allUnits[i];
				if (currentUnit != this)
				{
					float currentNeighbourDistanceSqr =
						Vector3.SqrMagnitude(currentUnit.MyTransform.position - MyTransform.position);
					if (currentNeighbourDistanceSqr <= _assignedSwarm.CohesionDistance * _assignedSwarm.CohesionDistance)
					{
						_cohesionNeighbours.Add(currentUnit);
					}

					if (currentNeighbourDistanceSqr <=
					    _assignedSwarm.AvoidanceDistance * _assignedSwarm.AvoidanceDistance)
					{
						_avoidanceNeighbours.Add(currentUnit);
					}

					if (currentNeighbourDistanceSqr <=
					    _assignedSwarm.AlignmentDistance * _assignedSwarm.AlignmentDistance)
					{
						_aligementNeighbours.Add(currentUnit);
					}
				}
			}
		}

		private void CalculateSpeed()
		{
			if (_cohesionNeighbours.Count == 0)
				return;
			_speed = 0;
			for (int i = 0; i < _cohesionNeighbours.Count; i++)
			{
				_speed += _cohesionNeighbours[i]._speed;
			}

			_speed /= _cohesionNeighbours.Count;
			_speed = Mathf.Clamp(_speed, _assignedSwarm.MinSpeed, _assignedSwarm.MaxSpeed);
		}

		private Vector3 CalculateCohesionVector()
		{
			Vector3 cohesionVector = Vector3.zero;
			if (_cohesionNeighbours.Count == 0)
				return Vector3.zero;
			int neighboursInFOV = 0;
			for (int i = 0; i < _cohesionNeighbours.Count; i++)
			{
				if (IsInFOV(_cohesionNeighbours[i].MyTransform.position))
				{
					neighboursInFOV++;
					cohesionVector += _cohesionNeighbours[i].MyTransform.position;
				}
			}

			cohesionVector /= neighboursInFOV;
			cohesionVector -= MyTransform.position;
			cohesionVector = cohesionVector.normalized;
			return cohesionVector;
		}

		private Vector3 CalculateAligementVector()
		{
			Vector3 aligementVector = MyTransform.forward;
			if (_aligementNeighbours.Count == 0)
				return MyTransform.forward;
			int neighboursInFOV = 0;
			for (int i = 0; i < _aligementNeighbours.Count; i++)
			{
				if (IsInFOV(_aligementNeighbours[i].MyTransform.position))
				{
					neighboursInFOV++;
					aligementVector += _aligementNeighbours[i].MyTransform.forward;
				}
			}

			aligementVector /= neighboursInFOV;
			aligementVector = aligementVector.normalized;
			return aligementVector;
		}

		private Vector3 CalculateAvoidanceVector()
		{
			Vector3 avoidanceVector = Vector3.zero;
			if (_aligementNeighbours.Count == 0)
				return Vector3.zero;
			int neighboursInFOV = 0;
			for (int i = 0; i < _avoidanceNeighbours.Count; i++)
			{
				if (IsInFOV(_avoidanceNeighbours[i].MyTransform.position))
				{
					neighboursInFOV++;
					avoidanceVector += (MyTransform.position - _avoidanceNeighbours[i].MyTransform.position);
				}
			}

			avoidanceVector /= neighboursInFOV;
			avoidanceVector = avoidanceVector.normalized;
			return avoidanceVector;
		}

		private Vector3 CalculateBoundsVector()
		{
			Vector3 offsetToCenter = _assignedSwarm.transform.position - MyTransform.position;
			bool isNearCenter = (offsetToCenter.magnitude >= _assignedSwarm.BoundsDistance * 0.9f);
			return isNearCenter ? offsetToCenter.normalized : Vector3.zero;
		}

		private Vector3 CalculateObstacleVector()
		{
			Vector3 obstacleVector = Vector3.zero;
			RaycastHit hit;
			if (Physics.Raycast(MyTransform.position, MyTransform.forward, out hit, _assignedSwarm.ObstacleDistance,
				    obstacleMask))
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
				if (!Physics.Raycast(MyTransform.position, MyTransform.forward, out hit, _assignedSwarm.ObstacleDistance,
					    obstacleMask))
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
					MyTransform.TransformDirection(directionsToCheckWhenAvoidingObstacles[i].normalized);
				if (Physics.Raycast(MyTransform.position, currentDirection, out hit, _assignedSwarm.ObstacleDistance,
					    obstacleMask))
				{

					float currentDistance = (hit.point - MyTransform.position).sqrMagnitude;
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

		private bool IsInFOV(Vector3 position)
		{
			return Vector3.Angle(MyTransform.forward, position - MyTransform.position) <= fovAngle;
		}
	}
}
