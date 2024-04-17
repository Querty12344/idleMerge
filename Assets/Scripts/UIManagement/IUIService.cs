namespace UIManagement
{
    public interface IUIService
    {
        void OpenWindow(WindowTypes type);
        void ShowCurtain();
        void HideCurtain();
        void SwitchWindow(WindowTypes type);
    }
}