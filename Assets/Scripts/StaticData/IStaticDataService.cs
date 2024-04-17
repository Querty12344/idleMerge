using AssetManagement;
using StaticData;
using UIManagement;

public interface IStaticDataService
{
    void LoadResources();
    WindowData GetWindow(WindowTypes type);
    UIMediator GetUIBase();
    WorkerData GetWorker(WorkerTypes type, int level);
    GameData GetGameData();
    OreData GetOre(string id);
    EconomyData GetEconomyData();
    FieldGenerationSettings GetFieldGenerationSettings();
    OreData[] GetAllOre();
}