using DemoApp.Core.Actions;
using HSM;
using UnityEngine.EventSystems;

namespace DemoApp.Core.View
{
    public class NextTaskView : HSMViewComponent, IPointerClickHandler, IShowNextTaskMenu, IHideNextTaskMenu
    {
        
        public void OnPointerClick(PointerEventData eventData)
        {
            CreateAction<NextTaskRequestAction>().Dispatch();
        }

        public void ShowNextTaskMenu()
        {
            this.gameObject.SetActive(true);
        }

        public void HideNextTaskMenu()
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
