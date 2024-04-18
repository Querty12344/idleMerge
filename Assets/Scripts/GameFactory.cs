using System.Linq;
using System.Threading.Tasks;
using AssetManagement;
using DefaultNamespace.Field;
using DefaultNamespace.FieldGenerator;
using DefaultNamespace.GamePlay.Ore;
using DefaultNamespace.GamePlay.Ore.Buillding;
using DefaultNamespace.GamePlay.Ore.WorkerComponents;
using DefaultNamespace.InputService;
using DefaultNamespace.LevelPositionHandler;
using Extensions;
using RandomManagement;
using StaticData;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

namespace DefaultNamespace
{
    internal class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _asset;
        private readonly DiContainer _container;
        private readonly ProgressSaversReadersPool _progressPool;
        private readonly IProgressService _progressService;
        private readonly IStaticDataService _staticData;
        private LevelScene _levelScene;
        private MiningField _miningField;
        private readonly IRandomService _randomService;

        public GameFactory( DiContainer container,  ProgressSaversReadersPool progressPool, IAssetProvider asset,
            IStaticDataService staticData, IProgressService progressService , IRandomService randomService)
        {
            _randomService = randomService;
            _container = container;
            _progressPool = progressPool;
            _asset = asset;
            _staticData = staticData;
            _progressService = progressService;
        }

        public void Initialize()
        {
            _levelScene = Object.FindObjectOfType<LevelScene>();
            ConstructField();
            ConstrucBuilding();
        }

        private void ConstrucBuilding()
        {
            string[] buildingsIDs = _staticData.GetBuildingsIDs();
            int[] choosen = _randomService.GetRandomArray(0 , buildingsIDs.Length , _levelScene.BuildingPlaces.Length);
            for (var i = 0; i < _levelScene.BuildingPlaces.Length; i++)
            {
                var buildingPlace = _levelScene.BuildingPlaces[i];
                CreateBuilding(buildingsIDs[choosen[i]], buildingPlace);
            }
        }

        private void ConstructField()
        {
            _miningField = _levelScene.Field;
            _miningField.Construct(this, _container.Resolve<IWorkerMerger>(), _container.Resolve<IFieldGenerator>());
            _progressPool.AddProgressSaver(_miningField); 
            _container.Resolve<IFieldConstructor>().RestoreField(_miningField);
        }

        public void Cleanup()
        {
            _progressPool.RemoveSaver(_miningField);
            _miningField.Clear();
        }

        public async Task<WorkerFacade> CreateWorker(WorkerTypes type, int level, FieldCell at)
        {
            WorkerData data;
            data = _staticData.GetWorker(type, level);
            var prefab = await _asset.Load<GameObject>(data.Prefab);
            var worker = Object.Instantiate(prefab, at.GetRoot().position, Quaternion.identity)
                .GetComponent<WorkerFacade>();
            worker.GetComponent<WorkerMover>().Construct(_miningField, at , _container.Resolve<IInputService>());
            WorkerMiner miner = worker.GetComponent<WorkerMiner>();
            miner.Construct(data.Strength);
            worker.Construct(data.Level, data.Type);
            at.Fill(worker);
            miner.TryStartMining();

            return worker;
        }

        public async Task<Ore> CreateOre(string id, FieldCell at)
        {
            var data = _staticData.GetOre(id);     
            var prefab = await _asset.Load<GameObject>(data.PrefabReference);
            if (prefab == null)
            {
                Debug.LogError("NULLLL");
            }
            var ore = Object.Instantiate(prefab, at.GetRoot().position, Quaternion.identity).GetComponent<Ore>();
            ore.Construct(_container.Resolve<IEffectsFactory>() ,data.Level ,data.ID , data.HP, data.MoneyReward, data.GemReward);
            at.Fill(ore);
            return ore;
        }
        public async Task<Building> CreateBuilding( string id, Transform at)
        {
            BuildingData data = _staticData.GetBuilding(id);     
            GameObject prefab = await _asset.Load<GameObject>(data.PrefabReference);
            Building building = Object.Instantiate(prefab, at.position , at.rotation).GetComponent<Building>();
            return building;
        }

        public void CreateRandom(int level)
        {
            CreateWorker(_progressService.GetActiveWorkerType(), level, _miningField.GetRandomCell());
        }
    }
}