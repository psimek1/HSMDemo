using DemoApp.Core.Actions;
using HSM;
using UnityEngine.EventSystems;

namespace DemoApp.Core.View
{
    public class BackButtonView: HSMViewComponent, IShowMenu, IHideMenu, IPointerClickHandler
    {
        public void Awake()
        {
            Deactivate();
        }

        public void ShowMenu()
        {
            Deactivate();
        }

        public void HideMenu()
        {
            Activate();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            CreateAction<BackAction>().Dispatch();
        }
    }
}
