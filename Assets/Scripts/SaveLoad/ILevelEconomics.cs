using System;
using StaticData;

namespace GamePlay
{
    public interface ILevelEconomics
    {
        int MoneyCount { get; }
        void SetData(EconomyData data);
        event Action<int> MoneyChanged;
        void Clear();
        void AddMoney(int amount);
        bool TryGetMoney(int cost);
        void GetWorkerLevel(int buyCount, out int i, out float f);
    }
}