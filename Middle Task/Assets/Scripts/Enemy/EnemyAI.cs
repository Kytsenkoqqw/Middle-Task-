using System;
using State;
using UnityEngine;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private PatrolEnemy _patrolEnemy;
        private ArcherEnemy _archerEnemy;
        public EnemyType enemyType;
        
        private void Start()
        {
            _stateMachine = new StateMachine();
            _patrolEnemy = GetComponent<PatrolEnemy>();
            _archerEnemy = GetComponent<ArcherEnemy>();

            switch (enemyType)
            {
                case EnemyType.PatrolEnemy:
                    _stateMachine.Initialize(new PatrollingState(_stateMachine, _patrolEnemy));
                    break;
                
                case EnemyType.ArcherEnemy:
                    _stateMachine.Initialize(new ShootingState(_stateMachine, _archerEnemy));
                    break;
            }
        }

        private void Update()
        {
            _stateMachine.Update();
        }
        
    }
}