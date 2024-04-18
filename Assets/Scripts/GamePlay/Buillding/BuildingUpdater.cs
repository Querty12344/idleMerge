using DefaultNamespace.Balance;
using GamePlay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.GamePlay.Ore.Buillding
{
    public class BuildingUpdater:UIEconomyElement
    {
        private Building Building;
        [SerializeField] private Image _levelCompliteIndicator;
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _incomeText;
        private int dataToUpdateCount;
        private int level;

        protected override void CompletePurchase()
        {
            dataToUpdateCount = _buyCount%_data.ToUpdateCount;
            level = GetLevel();
            Building.UpdateLevel( level, dataToUpdateCount);
            _levelText.text = level.ToString();
            _levelCompliteIndicator.fillAmount = GetProgress();
        }
    }
}