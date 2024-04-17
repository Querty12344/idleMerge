using DefaultNamespace;

namespace StateManagement.States
{
    public class LoadLevelState : IState
    {
        private readonly IProgressService _progressService;


        public LoadLevelState(IProgressService progressService)
        {
            _progressService = progressService;
        }

        public void Enter(IStateMachine stateMachine)
        {
            if (_progressService.IsInCity())
                stateMachine.Enter<CityState>();
            else
                stateMachine.Enter<MiningState>();
        }
    }
}