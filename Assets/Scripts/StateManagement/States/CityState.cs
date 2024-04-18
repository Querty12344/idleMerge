using DefaultNamespace.Constants;
using GamePlay;
using UIManagement;

namespace StateManagement.States
{
    public class CityState : IExitableState
    {
        private readonly ILevelEconomics _levelEconomics;
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly IUIService _uiService;

        public CityState(ILevelEconomics levelEconomics, IUIFactory uiFactory, IUIService uiService,
            ISceneLoader sceneLoader)
        {
            _levelEconomics = levelEconomics;
            _uiFactory = uiFactory;
            _uiService = uiService;
            _sceneLoader = sceneLoader;
        }

        public void Enter(IStateMachine stateMachine)
        {
            _sceneLoader.Load(GameConstants.CitySceneName, InitScene);
        }

        public void Exit()
        {
            _uiFactory.Cleanup();
        }

        private void InitScene()
        {
            _uiFactory.Initialize();
            _uiService.OpenWindow(WindowTypes.City);
        }
    }
}