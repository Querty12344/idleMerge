using System;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    [CreateAssetMenu(menuName = "GlobalEconomy", fileName = "Economy")]
    public class EconomyData : ScriptableObject
    {
        public int WorkerToUpdateCount;
        public int WorkerCost;
        public float WorkerCostModifier;
    }
}