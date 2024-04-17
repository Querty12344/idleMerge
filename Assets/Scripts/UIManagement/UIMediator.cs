using DefaultNamespace;
using StateManagement;
using UnityEngine;

namespace UIManagement
{
    public class UIMediator : MonoBehaviour, IProgressReader
    {
        private IGameFactory _gameFactory;
        private IStateMachine _stateMachine;
        private IUIService _uiService;

        public void OnLoaded(ref PlayerProgress progress)
        {
        }


        public void Construct(IGameFactory gameFactory, IStateMachine stateMachine, IUIService uiService)
        {
            _gameFactory = gameFactory;
            _uiService = uiService;
            _stateMachine = stateMachine;
        }

        public void OpenSettings()
        {
            _uiService.SwitchWindow(WindowTypes.Settings);
        }

        public void SwitchInventory()
        {
            _uiService.SwitchWindow(WindowTypes.Inventory);
        }

        public void CreateWorker(int level)
        {
            _gameFactory.CreateRandom(level);
        }
    }
}