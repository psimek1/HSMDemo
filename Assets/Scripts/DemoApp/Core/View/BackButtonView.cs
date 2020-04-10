using DemoApp.Core.Actions;
using HSM;
using UnityEngine.EventSystems;

namespace DemoApp.Core.View
{
    public class BackButtonView: HSMViewComponent, IShowMenu, IHideMenu, IPointerClickHandler
    {
        public void Awake()
        {
            this.gameObject.SetActive(false);
        }

        public void ShowMenu()
        {
            this.gameObject.SetActive(false);
        }

        public void HideMenu()
        {
            this.gameObject.SetActive(true);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            CreateAction<BackAction>().Dispatch();
        }
    }
}
