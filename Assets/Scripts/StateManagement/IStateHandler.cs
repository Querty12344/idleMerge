namespace StateManagement
{
    public interface IStateHandler
    {
        IState GetState<TState>() where TState : IState;
    }
}