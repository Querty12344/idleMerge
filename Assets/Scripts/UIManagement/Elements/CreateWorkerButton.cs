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

        protected override void Buy()
        {
            base.Buy();
            _levelEconomics.GetWorkerLevel(_buyCount, out var level, out var toNextProgress);
            _uiMediator.CreateWorker(_buyCount);
            _levelCompliteIndicator.fillAmount = toNextProgress;
            _levelText.text = level.ToString();
        }
    }
}