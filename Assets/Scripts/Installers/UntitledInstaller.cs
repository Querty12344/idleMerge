using AssetManagement;
using Curtain;
using DefaultNamespace;
using DefaultNamespace.FieldGenerator;
using DefaultNamespace.GamePlay.Ore;
using DefaultNamespace.InputService;
using GamePlay;
using RandomManagement;
using StateManagement;
using StateManagement.States;
using StaticData;
using UIManagement;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    [SerializeField] private LoadingCurtain _curtain;
    [SerializeField] private Bootstrap.Bootstrap _bootstrap;

    public override void InstallBindings()
    {
        Container.Bind<IFieldGenerator>().To<FieldGenerator>().AsSingle();
        Container.Bind<IWorkerMerger>().To<WorkerMerger>().AsSingle();
        Container.Bind<IRandomService>().To<RandomServiceService>().AsSingle();
        Container.Bind<IInputService>().To<InputService>().AsSingle();
        Container.Bind<LoadingCurtain>().FromInstance(_curtain).AsSingle();
        Container.Bind<ProgressSaversReadersPool>().AsSingle();
        Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        Container.Bind<ILevelEconomics>().To<LevelEconomics>().AsSingle();
        Container.Bind<IProgressService>().To<ProgressService>().AsSingle();
        Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
        Container.Bind<IStateHandler>().To<StateHandler>().AsSingle();
        Container.Bind<BootstrapState>().AsSingle();
        Container.Bind<CityState>().AsSingle();
        Container.Bind<GameLoopState>().AsSingle();
        Container.Bind<LoadLevelState>().AsSingle();
        Container.Bind<MiningState>().AsSingle();
        Container.Bind<ResourceLoadingState>().AsSingle();
        Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        Container.Bind<IUIService>().To<UIService>().AsSingle();
        Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        Container.Bind<ICoroutineRunner>().FromInstance(_bootstrap).AsSingle();
    }
}