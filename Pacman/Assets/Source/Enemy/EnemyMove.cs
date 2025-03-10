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
        [SerializeField] private Transform _target;
        [SerializeField] private List<Transform> waypoints;
        [SerializeField] private float speedAgent;
        [SerializeField] private float waitTime;
        private int _currentWaypointIndex = 0;
        protected NavMeshAgent _agent;
        protected Coroutine _moveRoutine;

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
            Move(out _);
        }

        protected virtual void Move(out Coroutine moveRoutine, bool breakCondition = true)
        {
            moveRoutine = null;
            if (waypoints.Count == 0) return;
            _target = waypoints[_currentWaypointIndex];
            Move(out var localMoveRoutine);
            moveRoutine = localMoveRoutine;
            _moveRoutine = localMoveRoutine;
        }

        protected void StopCurrentMoveRoutine() => StopCoroutine(_moveRoutine);

        protected virtual void Move(Vector3 target, out Coroutine moveRoutine)
        {
            _moveRoutine = StartCoroutine(MoveToTarget(target));
            moveRoutine = _moveRoutine;
        }

        protected IEnumerator MoveToTarget(Vector3 target)
        {
            while (Vector3.Distance(_agent.transform.position, target) > 1f)
            {
                _agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
                yield return null;
            }

            
            yield return new WaitForSeconds(waitTime); //TODO remove from this coroutine to make if universal
            _currentWaypointIndex = Random.Range(0, waypoints.Count); //TODO remove from this coroutine to make if universal

            Move(out _);
        }
    }
}
