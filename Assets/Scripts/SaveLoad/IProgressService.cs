using AssetManagement;

namespace DefaultNamespace
{
    public interface IProgressService
    {
        void Save();
        void Load();
        string GetCurrentLevelName();
        bool IsInCity();
        int GetLevelMoney();
        void SetLevelMoney(int value);
        WorkerTypes GetActiveWorkerType();
        int GetLevelNumber();
        void NotifiObservers();
    }
}