using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Field;
using DefaultNamespace.GamePlay.Ore;
using DefaultNamespace.LevelPositionHandler;
using RandomManagement;
using StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DefaultNamespace.FieldGenerator
{
    class FieldGenerator : IFieldGenerator
    {
        private readonly FieldGenerationSettings _settings;
        private readonly IRandomService _randomService;
        private readonly IProgressService _progressService;
        private readonly IStaticDataService _staticData;
        public FieldGenerator( IProgressService progressService, IStaticDataService staticData , IRandomService randomService)
        {
            _staticData = staticData;
            _progressService = progressService;
            _randomService = randomService;
            _settings = staticData.GetFieldGenerationSettings();
        }
        

        public FieldData FillField(int[] fieldCellsWeights)
        {
            FieldData fieldData = new FieldData();
            List<CellData> cells = new List<CellData>();
            int gemCount = 0;
            for (var index = 0; index < fieldCellsWeights.Length; index++)
            {                                                                                                                        
                var fieldCellsWeight = fieldCellsWeights[index];
                CellData next = new CellData();
              //  int gemProbabitiyModiefer = (int)Math.Floor((double)100 * (1 - ((gemCount + 1) / (fieldCellsWeights.Length - index)) /
               //     (_settings.GemsOnFieldCount / fieldCellsWeights.Length)));
                if (FillCellRandom(0,fieldCellsWeight, next) )
                {
                    gemCount++;
                }

                cells.Add(next);
            }

            fieldData.Cells = cells.ToArray();
            return fieldData;
        }

        private bool FillCellRandom(int gemProbabilityCof,int weight,CellData cellData)
        {
            CellType cellType;
            int oreLevel = 0;
            bool isGem = false;
            if (weight == 0)
            {
                cellType = CellType.empty;
            }else if (weight < _settings.OreBound)
            {
                cellType = _randomService.Probability(_settings.OreBoundProbability) ? CellType.empty : CellType.ore;
            }
            else
            {
                cellType = CellType.ore;
            }
            cellData.CellType = cellType;
            if (cellType == CellType.ore)
            {
                oreLevel = weight + (int)Math.Pow(_progressService.GetLevelNumber() * _settings.ByLevelArifmModiefer, _settings.ByLevelGeometricmModiefer) + UnityEngine.Random.Range(-_settings.OreLevelDistortion , _settings.OreLevelDistortion);
                isGem = _randomService.Probability(_settings.GemProbability + gemProbabilityCof);
                OreData[] gems= _staticData.GetAllOre().ToList().Where(x=>x.Level == oreLevel).Where(x => x.IsGem).ToArray();
                string id = gems[UnityEngine.Random.Range(0,gems.Length)].ID;
                cellData.CellContentID = id;
            }
            return isGem;
        }
        
    }
}