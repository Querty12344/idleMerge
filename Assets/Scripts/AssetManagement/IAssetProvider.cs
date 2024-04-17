using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace AssetManagement
{
    public interface IAssetProvider
    {
        void Initialize();
        public Task<T> Load<T>(AssetReference assetReference) where T : class;
        public Task<T> Load<T>(string address) where T : class;
        void Cleanup();
    }
}