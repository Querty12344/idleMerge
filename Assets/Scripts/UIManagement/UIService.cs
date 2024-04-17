using System.Collections.Generic;
using Curtain;

namespace UIManagement
{
    internal class UIService : IUIService
    {
        private readonly LoadingCurtain _curtain;
        private readonly IUIFactory _uiFactory;
        public List<WindowBase> _existingWindows;

        public UIService(IUIFactory uiFactory, LoadingCurtain curtain)
        {
            _uiFactory = uiFactory;
            _curtain = curtain;
            _existingWindows = new List<WindowBase>();
        }

        public void OpenWindow(WindowTypes type)
        {
            _existingWindows.ForEach(w => w.Close());

            if (WindowExists(type))
                _existingWindows.Find(x => x.GetType() == type).Open();
            else
                AddWindow(type);
        }

        public void ShowCurtain()
        {
            _curtain.Show();
        }

        public void HideCurtain()
        {
            _curtain.Hide();
        }

        public void SwitchWindow(WindowTypes type)
        {
            if (WindowExists(type))
            {
                var window = _existingWindows.Find(x => x.GetType() == type);
                if (window.IsOpen)
                    window.Close();
                else
                    window.Open();
            }
            else
            {
                AddWindow(type);
            }
        }

        private bool WindowExists(WindowTypes type)
        {
            return _existingWindows.Exists(x => x.GetType() == type);
        }

        private async void AddWindow(WindowTypes type)
        {
            var window = await _uiFactory.Create(type);
            window.Open();
            _existingWindows.Add(window);
        }
    }
}