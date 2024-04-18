using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData
{
    [Serializable]
    [CreateAssetMenu( menuName = "Effect" , fileName = "Effect")]
    public class EffectData : ScriptableObject
    {
        public string ID;
        public AssetReference PrefabReference;
    }
}