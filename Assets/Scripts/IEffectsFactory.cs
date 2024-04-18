using DefaultNamespace.GamePlay.Ore.Buillding;
using StaticData;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DefaultNamespace
{
    public interface IEffectsFactory
    {
        public void CreateEffect(AssetReference reference , Transform at , bool asChild);
    }
}