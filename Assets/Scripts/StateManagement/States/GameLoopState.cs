namespace StateManagement.States
{
    public class GameLoopState : IState
    {
        private IStateMachine _stateMachine;

        public void Enter(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void MoveNextState()
        {
        }
    }
}