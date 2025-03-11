using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemy
{
    public abstract class EnemyMove : MonoBehaviour
    { 
        [SerializeField] protected Transform _target;
        [SerializeField] private List<Transform> waypoints;
        [SerializeField] private float speedAgent;
        [SerializeField] private float waitTime;
        private int _currentWaypointIndex = 0;
        protected NavMeshAgent _agent;

        protected virtual void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = speedAgent;
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            waypoints = new List<Transform>(GameObject.Find("Waypoints").GetComponentsInChildren<Transform>());
            if (waypoints.Count > 0)
            {
                waypoints.RemoveAt(0);
            }
            Move();
        }

        protected void Move()
        {
            if (waypoints.Count == 0) return;
            _target = waypoints[_currentWaypointIndex];
           MoveToTarget(_target.position);
            Debug.Log("я сработал");
        }
        
        protected virtual void MoveToTarget(Vector3 target)
        {
            while (Vector3.Distance(_agent.transform.position, target) > 1f)
            {
                _agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
            }
            _currentWaypointIndex = Random.Range(0, waypoints.Count); 
            Move();
        }
    }
}
