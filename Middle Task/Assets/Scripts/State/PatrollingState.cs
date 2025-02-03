using Enemy;
using UnityEngine;

namespace State
{
    public class PatrollingState : BaseState
    {
        private PatrolEnemy _patrolEnemy;
        public PatrollingState(StateMachine stateMachine, PatrolEnemy patrolEnemy) : base(stateMachine)
        {
            _patrolEnemy = patrolEnemy;
        }

        public override void EnterState()
        {
            Debug.Log("Enter in patrolling state");
        }

        public override void UpdateState()
        {
            _patrolEnemy.Patrolling();
        }

        public override void ExitState()
        {
            Debug.Log("Exit to patrolling state");
        }
    }
}