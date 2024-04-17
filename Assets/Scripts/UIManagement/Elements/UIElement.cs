using UIManagement.Elements;

namespace UIManagement
{
    public class UIElement : WindowComponent
    {
        protected UIMediator _uiMediator;

        public virtual void Construct(UIMediator uiMediator)
        {
            _uiMediator = uiMediator;
        }
    }
}