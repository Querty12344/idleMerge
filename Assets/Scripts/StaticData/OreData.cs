using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData
{
    [Serializable]
    [CreateAssetMenu(menuName = "OreData", fileName = "Ore")]
    public class OreData : ScriptableObject
    {
        public int Level;
        public AssetReferenceGameObject HitFxReference;
        public AssetReferenceGameObject BreakFxReference;
        public string ID;
        public int HP;
        public AssetReferenceGameObject PrefabReference;
        public int MoneyReward;
        public bool IsGem;
        public GemData GemReward;
    }
}