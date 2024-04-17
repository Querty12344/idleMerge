using System;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    [CreateAssetMenu(menuName = "GameData", fileName = "Game")]
    public class GameData : ScriptableObject
    {
        public int MaxWorkerLevel;
        public string[] Levels;
        public string[] EndlessLevels;
    }
}