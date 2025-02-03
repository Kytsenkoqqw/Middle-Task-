namespace State
{
    public abstract class BaseState
    {
        protected StateMachine _stateMachine;

        protected BaseState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void ExitState();
    }
}