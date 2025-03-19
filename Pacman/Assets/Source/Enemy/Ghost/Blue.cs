using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : EnemyMovement
{
    private bool _toPlayer;
    private bool _isRunningAway = false;
    private float _turnProbability = 0.5f; 
    [SerializeField] private Transform player;
    [SerializeField] private Radius radius;

    protected override void Start()
    {
        base.Start();
        radius.OnPlayerDetect += RunAwayFromPlayer;
        radius.OnPlayerLeave += StopRunningAway;
    }

    protected override void Update()
    {
        if (_goHome == false)
        {
            if (_isRunningAway)
            {
                if (_toPlayer)
                {
                    _agent.SetDestination(player.position);
                }
                else
                {
                    Vector3 direction = (transform.position - player.position).normalized;
                    _agent.SetDestination(transform.position + direction);
                }
            }
            else
            {
                base.Update();
            }
        }
        else
        {
            _agent.SetDestination(home.position);
        }
    }

    private void RunAwayFromPlayer()
    {
        _isRunningAway = true;
        StartCoroutine(CheckTurnTowardsPlayer());
    }

    private void StopRunningAway()
    {
        _isRunningAway = false;
        Move(); 
        StopAllCoroutines();
    }

    private IEnumerator CheckTurnTowardsPlayer()
    {
        while (_isRunningAway)
        {
            yield return new WaitForSeconds(1); 
            
            if (Random.Range(0f,1f) < _turnProbability)
            {
                _toPlayer = true;
            }
            else
            {
                _toPlayer = false;
            }
        }
    }
    private void OnDestroy()
    {
        radius.OnPlayerDetect -= RunAwayFromPlayer;
        radius.OnPlayerLeave -= StopRunningAway;
    }

}
