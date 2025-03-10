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
        
        protected override void MoveToNextWaypoint()
        {
            base.MoveToNextWaypoint();
            if (Vector3.Distance(_agent.transform.position, player.position) < radius) 
            {
                _agent.SetDestination(player.position);
            }
            else
            {
                MoveToNextWaypoint();
            }
        }
        protected override IEnumerator MoveToTarget(Transform target)
        {
            if (Vector3.Distance(_agent.transform.position, player.position) < radius)
            {
                return base.MoveToTarget(player);
            }
            else
            {
                return base.MoveToTarget(target);
            }
        }
    }
}
