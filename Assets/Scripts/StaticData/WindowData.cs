using System;
using UIManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData
{
    [Serializable]
    [CreateAssetMenu(menuName = "WindowData", fileName = "Window")]
    public class WindowData : ScriptableObject
    {
        public AssetReferenceGameObject PrefabReference;
        public WindowTypes Type;
    }
}