using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData
{
    [Serializable]
    [CreateAssetMenu(menuName = "GemData", fileName = "Gem")]
    public class GemData : ScriptableObject
    {
        public int Index;
        public int Level;
        public AssetReferenceGameObject PrefabReference;
    }
}