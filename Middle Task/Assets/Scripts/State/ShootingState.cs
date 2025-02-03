using UnityEngine;

namespace State
{
    public class ShootingState : BaseState
    {
        private ArcherEnemy _archerEnemy;
        public ShootingState(StateMachine stateMachine, ArcherEnemy archerEnemy) : base(stateMachine)
        {
            _archerEnemy = archerEnemy;
        }

        public override void EnterState()
        {
            Debug.Log("Enter Shooting State");
        }

        public override void UpdateState()
        {
            _archerEnemy.FindCharacter();
        }

        public override void ExitState()
        {
            Debug.Log("Exit Shooting State");
        }
    }
}