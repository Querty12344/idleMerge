using System;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    [CreateAssetMenu(menuName = "EconomyElement", fileName = "EconomyElement")]
    public class LevelEconomyElementData : ScriptableObject
    {
        public int ToUpdateCount;
        public int MaxBuyCount;
        public int Cost;
        public float GeometricCof;
        public float ArifmeticCof;


    }
}