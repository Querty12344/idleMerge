using System;
using GamePlay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class CreateWorkerButton : UIEconomyElement
    {
        [SerializeField] private Image _levelCompliteIndicator;
        [SerializeField] private TMP_Text _levelText;

        protected override void CompletePurchase()
        {
            
            int workerLevel = GetLevel(); 
            _uiMediator.CreateWorker(workerLevel);
            _levelCompliteIndicator.fillAmount = GetProgress();
            _levelText.text = workerLevel.ToString();
        }
    }
}