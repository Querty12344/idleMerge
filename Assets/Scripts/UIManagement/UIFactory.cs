using System.Threading.Tasks;
using AssetManagement;
using DefaultNamespace;
using GamePlay;
using StateManagement;
using UnityEngine;
using Zenject;

namespace UIManagement
{
    internal class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly ProgressSaversReadersPool _progressPool;
        private readonly IStaticDataService _staticData;
        private readonly DiContainer _container;
        private ILevelEconomics _levelEconomics;
        private UIMediator _uiMediator;

        public UIFactory(DiContainer container, IAssetProvider assetProvider, IStaticDataService staticData,
            ProgressSaversReadersPool progressPool)
        {
            _container = container;
            _progressPool = progressPool;
            _assetProvider = assetProvider;
            _staticData = staticData;
        }

        public void Initialize(ILevelEconomics levelEconomics)
        {
            _levelEconomics = levelEconomics;
            _uiMediator = Object.Instantiate(_staticData.GetUIBase());
            _uiMediator.Construct(_container.Resolve<IGameFactory>(), _container.Resolve<IStateMachine>(),
                _container.Resolve<IUIService>());
            _progressPool.AddProgressReader(_uiMediator);
        }

        public void Cleanup()
        {
            _progressPool.RemoveReader(_uiMediator);
            Object.Destroy(_uiMediator.gameObject);
        }

        public async Task<WindowBase> Create(WindowTypes type)
        {
            var data = _staticData.GetWindow(type);
            var prefab = (await _assetProvider.Load<GameObject>(data.PrefabReference)).GetComponent<WindowBase>();
            var window = Object.Instantiate(prefab, _uiMediator.transform);
            window.Construct(_uiMediator);
            var components = window.WindowComponents;
            foreach (var component in components)
            {
                if (component is UIEconomyElement element) element.Construct(_levelEconomics, _uiMediator);
                if (component is UIElement uiElement) uiElement.Construct(_uiMediator);
            }

            return window;
        }
    }
}