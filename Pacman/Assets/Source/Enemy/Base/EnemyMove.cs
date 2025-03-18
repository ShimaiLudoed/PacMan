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
        private int _currentWaypointIndex = 0;
        protected NavMeshAgent _agent;
        protected bool _goHome=false;
        [SerializeField] protected Transform home;

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

        protected virtual void Update()
        {
            if (Vector3.Distance(transform.position, _target.position) < .2f)
            {
                Move();
            }
        }

        public void GoHome()
        {
            _goHome = true;
        }
        public void Move()
        {
            if (waypoints.Count == 0) return;
            _currentWaypointIndex = Random.Range(0, waypoints.Count);
            _target = waypoints[_currentWaypointIndex];
            Debug.Log("я сработал");
            _agent.SetDestination(_target.position);
        }
    }
}
