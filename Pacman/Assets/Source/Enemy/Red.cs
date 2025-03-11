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
        }

        private void StopChase()
        {
            _isChase = false;
            Move();
        }

 
    }
}
