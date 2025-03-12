using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    public class Red : EnemyMove
    {
        public bool _isChase=false;
        //[SerializeField] private LayerMask playerLayer;
        [SerializeField] private Transform player;
        [SerializeField] private Radius radius;
        
        protected override void Start()
        {
            base.Start();
            radius.OnPlayerDetect += ChasePlayer;
            radius.OnPlayerLeave += StopChase;
        }
        private void ChasePlayer()
        {
            _isChase = true;
            MoveToTarget(player.position);
        }

        private void StopChase()
        {
            _isChase = false;
            Move();
        }

        protected override void MoveToTarget(Vector3 target)
        {
            if (_isChase == false)
            {
                base.MoveToTarget(target);   
            }
            else
            {
                while (Vector3.Distance(_agent.transform.position, player.position)>1)
                {
                    _agent.SetDestination(new Vector3(player.position.x, player.position.y, transform.position.z));
                }
                MoveToTarget(player.position);
            }
        }
    }
}
