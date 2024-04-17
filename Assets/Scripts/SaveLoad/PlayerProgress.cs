using System;
using AssetManagement;
using StaticData;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    [Serializable]
    public class PlayerProgress
    {
        [FormerlySerializedAs("ActiveLevelNumberr")] public int ActiveLevelNumber;
        public WorkerTypes ActiveWorkerType;
        public int LevelMoney;
        public int CurrentLevel;
        public GameData GameData;
        public int Coins;
        public int[] GemsIds;
        public WorkerTypes[] BoughtWorkers;
        public FieldData FieldData;
        public bool IsInCity;

        public string GetCurrentLevelName()
        {
            if (GameData.Levels.Length <= CurrentLevel - 1)
                return GameData.EndlessLevels[Random.Range(0, GameData.EndlessLevels.Length)];
            return GameData.Levels[CurrentLevel];
        }
    }
}