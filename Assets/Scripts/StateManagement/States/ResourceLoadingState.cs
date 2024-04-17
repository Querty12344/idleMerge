using AssetManagement;
using DefaultNamespace;
using GamePlay;

namespace StateManagement.States
{
    public class ResourceLoadingState : IState
    {
        private readonly IAssetProvider _assetProvider;
        private readonly ILevelEconomics _levelEconomics;
        private readonly IProgressService _progressService;
        private readonly IStaticDataService _staticDataService;

        public ResourceLoadingState(IProgressService progressService, IStaticDataService staticDataService,
            IAssetProvider assetProvider, ILevelEconomics levelEconomics)
        {
            _levelEconomics = levelEconomics;
            _progressService = progressService;
            _staticDataService = staticDataService;
            _assetProvider = assetProvider;
        }

        public void Enter(IStateMachine stateMachine)
        {
            _assetProvider.Initialize();
            _staticDataService.LoadResources();
            _progressService.Load();
            _levelEconomics.SetData(_staticDataService.GetEconomyData());
            stateMachine.Enter<LoadLevelState>();
        }
    }
}