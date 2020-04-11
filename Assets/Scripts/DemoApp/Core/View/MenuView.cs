using HSM;

namespace DemoApp.Core.View
{
    public class MenuView: HSMViewComponent, IShowMenu, IHideMenu
    {
        public void Awake()
        {
            Deactivate();
        }

        public void ShowMenu()
        {
            Activate();
        }

        public void HideMenu()
        {
            Deactivate();
        }
    }
}
