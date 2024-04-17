using System.Threading.Tasks;
using GamePlay;

namespace UIManagement
{
    public interface IUIFactory
    {
        void Cleanup();
        void Initialize(ILevelEconomics levelEconomics);
        Task<WindowBase> Create(WindowTypes type);
    }
}