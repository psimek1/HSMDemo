using HSM;

namespace DemoApp.Core.View
{
    public class MenuView: HSMViewComponent, IShowMenu, IHideMenu
    {
        public void Awake()
        {
            this.gameObject.SetActive(false);
        }

        public void ShowMenu()
        {
            this.gameObject.SetActive(true);
        }

        public void HideMenu()
        {
            this.gameObject.SetActive(false);
        }
    }
}
