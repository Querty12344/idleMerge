namespace StateManagement
{
    public interface IState
    {
        public void Enter(IStateMachine stateMachine);
    }
}