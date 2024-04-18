using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Balance;
using GamePlay;
using StaticData;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.GamePlay.Ore.Buillding
{
    public class Building:MonoBehaviour
    {
        private IEffectsFactory _effectsFactory;
        private BuildingData Data { get; set; }
        private ILevelEconomics _levelEconomics;
        private int _level;
        private int _toNextLevelCount;
        private IEconomyCalculator _economyCalculator;
        private float _timer;
        

        public int Income() => _economyCalculator.CalculateBuildingReward(_level, _toNextLevelCount, Data);

        public void Construct( IEconomyCalculator economyCalculator, IEffectsFactory effectsFactory,ILevelEconomics levelEconomics,BuildingData buildingData)
        {
            _economyCalculator = economyCalculator;
            _effectsFactory = effectsFactory;
            _levelEconomics = levelEconomics;
            Data = buildingData;
        }

        public void UpdateLevel(int level , int toNextCount)
        {
            _toNextLevelCount = toNextCount;
            _level = level;
        }

        private void Update()
        {
            if(_timer >= Data.RewardTime)
            {
                _timer = 0;
                _effectsFactory.CreateEffect(Data.rewardEffectReference,transform , false);
                int reward = _economyCalculator.CalculateBuildingReward(_level , _toNextLevelCount, Data);
                _levelEconomics.AddMoney(reward); 
            }
            _timer += Time.deltaTime;
        }

        public float IncomeProgress() => _timer / Data.RewardTime;
    }
}