using System;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    [CreateAssetMenu(menuName = "EconomyElement", fileName = "EconomyElement")]
    public class LevelEconomyElementData : ScriptableObject
    {
        public int MaxBuyCount;
        public int Cost;
        public float GeometricCof;
        public float ArifmeticCof;

        public int CalculateCost(int buyCount)
        {
            return (int)Math.Round(Math.Round(Math.Pow(Cost + buyCount * ArifmeticCof, GeometricCof)), 0);
        }
    }
}