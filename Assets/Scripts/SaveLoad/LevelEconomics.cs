using System;
using DefaultNamespace;
using StaticData;
using UnityEngine;

namespace GamePlay
{
    public class LevelEconomics : ILevelEconomics
    {
        private readonly IProgressService _progressService;
        private EconomyData _economyData;

        public LevelEconomics(IStaticDataService staticData, IProgressService progressService)
        {
            _progressService = progressService;
        }

        public void SetData(EconomyData data)
        {
            _economyData = data;
        }

        public event Action<int> MoneyChanged;

        public int MoneyCount
        {
            get => _progressService.GetLevelMoney();
            private set => _progressService.SetLevelMoney(value);
        }

        public void Clear()
        {
            MoneyCount = 0;
        }

        public void AddMoney(int amount)
        {
            MoneyCount += amount;
        }

        public bool TryGetMoney(int cost)
        {
            if (MoneyCount >= cost)
            {
                MoneyCount -= cost;
                return true;
            }

            return false;
        }

        public void GetWorkerLevel(int buyCount, out int level, out float progress)
        {
            level = (int)Math.Floor((double)buyCount / _economyData.WorkerToUpdateCount);
            progress = (float)(buyCount % _economyData.WorkerToUpdateCount) / _economyData.WorkerToUpdateCount;
        }
    }
}