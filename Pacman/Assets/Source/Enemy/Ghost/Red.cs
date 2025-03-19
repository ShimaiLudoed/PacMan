
using UnityEngine;


namespace Enemy
{
    public class Red : EnemyMove
    {
        public bool _isChase=false;
        [SerializeField] private Transform player;
        [SerializeField] private Radius radius;
        
        protected override void Start()
        {
            base.Start();
            radius.OnPlayerDetect += ChasePlayer;
            radius.OnPlayerLeave += StopChase;
        }

        protected override void Update()
        {
            if (_isChase == false)
            {
                base.Update();   
            }
            if (_isChase == true)
            {
                _agent.SetDestination(player.position);
            }
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

        private void OnDestroy()
        {
            radius.OnPlayerDetect -= ChasePlayer;
            radius.OnPlayerLeave -= StopChase;
        }
    }
}
