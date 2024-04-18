using AssetManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DefaultNamespace
{
    class EffectsFactory : IEffectsFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;

        public EffectsFactory(IStaticDataService staticData, IAssetProvider assets)
        {
            _staticData = staticData;
            _assets = assets;
        }

        public async void CreateEffect(AssetReference reference , Transform at , bool asChild)
        {
            if(reference == null)
                return;
            GameObject prefab = await _assets.Load<GameObject>(reference);
            if (asChild)
            {
                Object.Instantiate(prefab, at.position , at.rotation).transform.SetParent(at);
                
            }
            else
            {
                Object.Instantiate(prefab, at.position, at.rotation);
            }
        }
    }
}