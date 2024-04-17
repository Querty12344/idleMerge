namespace StateManagement
{
    internal class StateMachine : IStateMachine
    {
        private readonly IStateHandler _stateHandler;
        private IState _activeState;

        public StateMachine(IStateHandler stateHandler)
        {
            _stateHandler = stateHandler;
        }

        public void Enter<TState>() where TState : IState
        {
            if (_activeState is IExitableState exitableState) exitableState.Exit();
            var next = _stateHandler.GetState<TState>();
            next.Enter(this);
            _activeState = next;
        }
    }
}