using System;
using DefaultNamespace.Balance;
using StaticData;
using TMPro;
using UIManagement;
using UIManagement.Elements;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace GamePlay
{
    public abstract class UIEconomyElement : WindowComponent
    {
        [SerializeField] protected LevelEconomyElementData _data;
        [SerializeField] protected TMP_Text _costText;
        [SerializeField] protected Button _button;
        protected int _buyCount;
        protected ILevelEconomics _levelEconomics;
        protected UIMediator _uiMediator;
        protected IEconomyCalculator _economyCalculator;

        public virtual void Construct(IEconomyCalculator economyCalculator , ILevelEconomics levelEconomics, UIMediator uiMediator)
        {
            _economyCalculator = economyCalculator;
            _uiMediator = uiMediator;
            _levelEconomics = levelEconomics;
            _levelEconomics.MoneyChanged += UpdateElement;
            UpdateElement(_levelEconomics.MoneyCount);
            _button.onClick.AddListener(TryBuy);
        }

        protected virtual void UpdateElement(int budjet)
        {
            var cost = _economyCalculator.CalculateCost(_buyCount, _data);
            _costText.text = cost.ToString();
            //   _button.enabled = budjet >= cost;
        }

        protected void TryBuy()
        {
            if (!_levelEconomics.TryGetMoney(_economyCalculator.CalculateCost(_buyCount, _data)))
                return;
            _buyCount++;
            CompletePurchase();
        }

        protected int GetLevel()
        {
            Debug.LogError(" level " + (int)Math.Floor((double)(_buyCount / _data.ToUpdateCount)) );
            Debug.LogError(" buy "  + _buyCount);
            return (int)Math.Floor((double)_buyCount / _data.ToUpdateCount);
        }

        protected float GetProgress()
        {
            return (_buyCount % _data.ToUpdateCount) / _data.ToUpdateCount;
        }
        protected abstract void CompletePurchase();
    }
}