using UIManagement;

namespace StateManagement.States
{
    public class BootstrapState : IState
    {
        private readonly IUIService ui;

        public BootstrapState(IUIService ui)
        {
            this.ui = ui;
        }

        public void Enter(IStateMachine stateMachine)
        {
            ui.ShowCurtain();
            stateMachine.Enter<ResourceLoadingState>();
        }
    }
}