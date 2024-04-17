using System.Collections.Generic;
using System.Linq;
using AssetManagement;
using TMPro;
using UIManagement;
using UnityEngine;

namespace StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private EconomyData _economyData;
        private GameData _gameData;
        private GemData[] _gems;
        private bool _initialized;
        private Dictionary<string, OreData> _ore;
        private UIMediator _uiMediator;
        private Dictionary<WindowTypes, WindowData> _windows;
        private Dictionary<WorkerTypes, List<WorkerData>> _workers;
        private FieldGenerationSettings _generationSettings;
        public void LoadResources()
        {
            if (_initialized) return;
            _initialized = true;
            _generationSettings = Resources.Load<FieldGenerationSettings>(AssetPath.GenerationSettings);
            _economyData = Resources.Load<EconomyData>(AssetPath.EconomyData);
            _uiMediator = Resources.Load<UIMediator>(AssetPath.UIMediator);
            _gems = Resources.LoadAll<GemData>(AssetPath.Gems);
            var allWorkers = Resources.LoadAll<WorkerData>(AssetPath.Workers);
            _workers = allWorkers.GroupBy(x => x.Type).ToDictionary(x => x.Key, x => x.ToList());
            _windows = Resources.LoadAll<WindowData>(AssetPath.Windows).ToDictionary(x => x.Type, x => x);
            _ore = Resources.LoadAll<OreData>(AssetPath.Ore).ToDictionary(x => x.ID, x => x);
            _gameData = Resources.Load<GameData>(AssetPath.GameData);
        }

        public WorkerData GetWorker(WorkerTypes type, int level)
        {

            var ret = _workers[type][level];
            return ret;
        }

        public GameData GetGameData()
        {
            return _gameData;
        }

        public OreData GetOre(string id)
        {
            return _ore[id];
        }

        public EconomyData GetEconomyData()
        {
            return _economyData;
        }

        public FieldGenerationSettings GetFieldGenerationSettings()
        {
            return _generationSettings;
        }

        public OreData[] GetAllOre()
        {
            return _ore.Values.ToArray();
        }

        public WindowData GetWindow(WindowTypes type)
        {
            return _windows[type];
        }

        public UIMediator GetUIBase()
        {
            return _uiMediator;
        }
    }
}