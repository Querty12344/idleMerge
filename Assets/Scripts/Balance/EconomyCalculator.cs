using System;
using StaticData;

namespace DefaultNamespace.Balance
{
    class EconomyCalculator : IEconomyCalculator
    {
        public int CalculateCost(int buyCount , LevelEconomyElementData data)
        {
            return (int)Math.Floor(Math.Round(Math.Pow(data.Cost + buyCount * data.ArifmeticCof, data.GeometricCof)));
        }

        public int CalculateBuildingReward(int level, int toNextLevelCount, BuildingData buildingData)
        {
            return (int)Math.Floor(Math.Round(Math.Pow(buildingData.Income + toNextLevelCount * buildingData.IncomeArifmModiefer, buildingData.IncomeGeomModiefer)));
        }
    }
}