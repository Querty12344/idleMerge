using UnityEngine;
using UnityEngine.UI;

namespace UIManagement
{
    public class OpenSettingsButton : UIElement
    {
        [SerializeField] private Button _button;

        public override void Construct(UIMediator uiMediator)
        {
            base.Construct(uiMediator);
            _button.onClick.AddListener(uiMediator.OpenSettings);
        }
    }
}