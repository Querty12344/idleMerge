using AssetManagement;
using UnityEngine;

namespace DefaultNamespace
{
    internal class ProgressService : IProgressService
    {
        private readonly ProgressSaversReadersPool _pool;
        private readonly SaveLoadProgress _saveLoadProgress;
        private readonly IStaticDataService _staticDataService;
        private PlayerProgress _progress;

        public ProgressService(ProgressSaversReadersPool pool, IStaticDataService staticDataService)
        {
            _pool = pool;
            _staticDataService = staticDataService;
            _saveLoadProgress = new SaveLoadProgress();
        }

        public void Save()
        {
            _pool.ProgressSavers.ForEach(x =>
            {
                if (x != null) x.Save(ref _progress);
            });
            _saveLoadProgress.SaveProgress(ref _progress);
        }

        public void Load()
        {
            _progress = _saveLoadProgress.LoadProgress();
            if (_progress == null) SetDefaultProgress();
            //Remove
            SetDefaultProgress();
            NotifiObservers();
        }

        public string GetCurrentLevelName()
        {
            return _progress.GetCurrentLevelName();
        }

        public bool IsInCity()
        {
            return _progress.IsInCity;
        }

        public int GetLevelMoney()
        {
            return _progress.LevelMoney;
        }

        public void SetLevelMoney(int value)
        {
            _progress.LevelMoney = value;
        }

        public WorkerTypes GetActiveWorkerType()
        {
            return _progress.ActiveWorkerType;
        }

        public int GetLevelNumber()
        {
            return _progress.ActiveLevelNumber;
        }

        public void NotifiObservers()
        {
            _pool.ProgressReaders.ForEach(x =>
            {
                if (x != null) x.OnLoaded(ref _progress);
            });
        }

        private void SetDefaultProgress()
        {
            _progress = new PlayerProgress();
            _progress.IsInCity = false;
            _progress.Coins = 0;
            _progress.GameData = _staticDataService.GetGameData();
            _progress.BoughtWorkers = new[] { WorkerTypes.worker1 };
            _progress.GemsIds = null;
        }
    }
}