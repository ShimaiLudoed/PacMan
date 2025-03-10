using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : EnemyMove
{
    [SerializeField] private float escapeRadius;
    [SerializeField] private Transform player;

    private void EscapeFromPlayer()
    {
        Vector3 directionAwayFromPlayer = transform.position - player.position;
        Vector3 targetPosition = transform.position + directionAwayFromPlayer.normalized * escapeRadius;

        _agent.SetDestination(targetPosition);
    }
}
