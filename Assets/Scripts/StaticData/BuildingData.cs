using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Serialization;

namespace StaticData
{
    [Serializable]
    [CreateAssetMenu(menuName = "BuildingData", fileName = "Building")]
    public class BuildingData:ScriptableObject

    {
    public float RewardTime;
    public AssetReference PrefabReference;
    public AssetReference rewardEffectReference;
    public AssetReference UpdateEffectReference;
    public int HP;
    public int Income;
    public int IncomeArifmModiefer;
    public int IncomeGeomModiefer;
    public string ID;
    public LevelEconomyElementData EconomyData;
    }
}