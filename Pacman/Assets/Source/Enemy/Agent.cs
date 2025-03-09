using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
  private Vector3 _target;
  private NavMeshAgent _agent;

  private void Start()
  {
    _agent = GetComponent<NavMeshAgent>();
    _agent.updateRotation = false;
    _agent.updateUpAxis = false;
  }

  private void Update()
  {
   SetTargetPos();
   SetAgentPos();
  }

  private void SetTargetPos()
  {
    if (Input.GetMouseButtonDown(0))
    {
      _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
  }

  private void SetAgentPos()
  {
    _agent.SetDestination(new Vector3(_target.x, _target.y, transform.position.z));
  }
  
}

