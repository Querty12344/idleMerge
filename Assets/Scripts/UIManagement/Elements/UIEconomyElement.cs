using StaticData;
using TMPro;
using UIManagement;
using UIManagement.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public abstract class UIEconomyElement : WindowComponent
    {
        [SerializeField] protected LevelEconomyElementData _economyElement;
        [SerializeField] protected TMP_Text _costText;
        [SerializeField] protected Button _button;
        protected int _buyCount;
        protected ILevelEconomics _levelEconomics;
        protected UIMediator _uiMediator;

        public virtual void Construct(ILevelEconomics levelEconomics, UIMediator uiMediator)
        {
            _uiMediator = uiMediator;
            _levelEconomics = levelEconomics;
            _levelEconomics.MoneyChanged += UpdateElement;
            UpdateElement(_levelEconomics.MoneyCount);
            _button.onClick.AddListener(Buy);
        }

        protected virtual void UpdateElement(int budjet)
        {
            var cost = _economyElement.CalculateCost(_buyCount);
            _costText.text = cost.ToString();
            //   _button.enabled = budjet >= cost;
        }

        protected virtual void Buy()
        {
            if (!_levelEconomics.TryGetMoney(_economyElement.CalculateCost(_buyCount)))
                return;
            _buyCount++;
        }
    }
}