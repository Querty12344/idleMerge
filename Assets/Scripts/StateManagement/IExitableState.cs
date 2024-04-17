namespace StateManagement
{
    public interface IExitableState : IState
    {
        void Exit();
    }
}