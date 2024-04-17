using System;
using AssetManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData
{
    [Serializable]
    [CreateAssetMenu]
    public class WorkerData : ScriptableObject
    {
        public float Strength;
        public int Level;
        public WorkerTypes Type;
        public AssetReferenceGameObject Prefab;
    }
}