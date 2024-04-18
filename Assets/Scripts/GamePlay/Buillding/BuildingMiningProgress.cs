using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.GamePlay.Ore.Buillding
{
    public class BuildingMiningProgress:MonoBehaviour
    {
        [SerializeField] private Building _building;
        [SerializeField] private Image _progressImage;
        [SerializeField] private TMP_Text _incomeText;

        public void Update()
        {
            _progressImage.fillAmount = _building.IncomeProgress();
            _incomeText.text = _building.Income().ToString(); 
        }
    }
}