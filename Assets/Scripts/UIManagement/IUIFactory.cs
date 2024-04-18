using System.Threading.Tasks;
using GamePlay;

namespace UIManagement
{
    public interface IUIFactory
    {
        void Cleanup();
        void Initialize();
        Task<WindowBase> Create(WindowTypes type);
    }
}