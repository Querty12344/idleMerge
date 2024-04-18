using StaticData;

namespace DefaultNamespace.Balance
{
    public interface IEconomyCalculator
    {
        public int CalculateCost(int buyCount, LevelEconomyElementData data);
        int CalculateBuildingReward(int level, int toNextLevelCount, BuildingData buildingData);
    }
}