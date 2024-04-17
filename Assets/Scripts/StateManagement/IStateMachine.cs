namespace StateManagement
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : IState;
    }
}