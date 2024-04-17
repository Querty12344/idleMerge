using StaticData;

namespace DefaultNamespace.GamePlay.Ore
{
    public class LevelResourceHandler
    {
        private readonly EconomyData _economyData;
        private readonly IProgressService _progressService;

        public LevelResourceHandler(IStaticDataService staticData, IProgressService progressService)
        {
            _progressService = progressService;
            _economyData = staticData.GetEconomyData();
        }

        public void InitializeLevel()
        {
        }
    }
}