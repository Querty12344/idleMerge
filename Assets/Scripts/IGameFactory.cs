using System.Threading.Tasks;
using AssetManagement;
using DefaultNamespace.Field;
using DefaultNamespace.GamePlay.Ore;

namespace DefaultNamespace
{
    public interface IGameFactory
    {
        void Initialize();
        void Cleanup();

        Task<WorkerFacade> CreateWorker(WorkerTypes type, int level, FieldCell at);
        Task<Ore> CreateOre(string id, FieldCell at);
        void CreateRandom(int level);
    }
}