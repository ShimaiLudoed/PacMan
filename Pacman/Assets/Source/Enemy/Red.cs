using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    public class Red : EnemyMove
    {
        [SerializeField] private Transform player;
        [SerializeField] private float radius;
        private bool _isChase = false;

        private void Update()
        {
            if (Vector3.Distance(_agent.transform.position, player.position) < radius)
            {
                ChasePlayer();
            }
        }

        private void ChasePlayer()
        {
            StopCurrentMoveRoutine();
            Move(player.position, out var moveRoutine);

        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
