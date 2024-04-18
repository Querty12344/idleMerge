using DefaultNamespace;
using GamePlay;
using UIManagement;

namespace StateManagement.States
{
    public class MiningState : IExitableState
    {
        private readonly IGameFactory _gameFactory;
        private readonly ILevelEconomics _levelEconomics;
        private readonly IProgressService _progressService;
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly IUIService _uiService;
        private IStateMachine _stateMachine;

        public MiningState(IUIFactory uiFactory, ILevelEconomics levelEconomics, IUIService uiService,
            IGameFactory gameFactory, IProgressService progressService, ISceneLoader sceneLoader)
        {
            _uiFactory = uiFactory;
            _uiService = uiService;
            _gameFactory = gameFactory;
            _levelEconomics = levelEconomics;
            _progressService = progressService;
            _sceneLoader = sceneLoader;
        }

        public void Enter(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _sceneLoader.Load(_progressService.GetCurrentLevelName(), InitScene);
        }

        public void Exit()
        {
            _uiFactory.Cleanup();
            _gameFactory.Cleanup();
            _levelEconomics.Clear();
            _progressService.Save();
        }

        private void InitScene()
        {
            _uiFactory.Initialize();
            _gameFactory.Initialize();
            _uiService.OpenWindow(WindowTypes.HUD);
            _progressService.NotifiObservers();
        }
    }
}