using UIManagement.Elements;
using UnityEngine;

namespace UIManagement
{
    public class WindowBase : MonoBehaviour
    {
        [SerializeField] protected WindowTypes _type;
        public WindowComponent[] WindowComponents;
        protected UIMediator _uiMediator;

        public bool IsOpen { get; }

        public WindowTypes GetType()
        {
            return _type;
        }

        public virtual void Construct(UIMediator uiMediator)
        {
            _uiMediator = uiMediator;
            WindowComponents = GetComponentsInChildren<WindowComponent>();
        }


        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}