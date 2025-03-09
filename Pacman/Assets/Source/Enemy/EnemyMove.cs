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
    private Transform _target;
    private Vector3 _currentVector;
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float speed; 
    [SerializeField] private float waitTime ; 
    private int _currentWaypointIndex = 0; 
    protected NavMeshAgent _agent;

    private void Start()
    {
      _agent = GetComponent<NavMeshAgent>();
      _agent.updateRotation = false;
      _agent.updateUpAxis = false;
      waypoints = new List<Transform>(GameObject.Find("Waypoints").GetComponentsInChildren<Transform>());
      if (waypoints.Count > 0)
      {
        waypoints.RemoveAt(0); 
        MoveToNextWaypoint();
      }
    }

    protected virtual void MoveToNextWaypoint()
    {
      if(waypoints.Count == 0) return;
       _target = waypoints[_currentWaypointIndex];
      _currentVector = _target.position;
      StartCoroutine(MoveToTarget(_target));
    }

    private IEnumerator MoveToTarget(Transform target)
    {
      while (Vector3.Distance(_agent.transform.position, target.position) > 1f)
      {
        _agent.SetDestination(new Vector3(_currentVector.x, _currentVector.y, transform.position.z));
        yield return null;
      }
      
      yield return new WaitForSeconds(waitTime);
      _currentWaypointIndex = Random.Range(0, waypoints.Count); 
      MoveToNextWaypoint();
    }
  }
}
