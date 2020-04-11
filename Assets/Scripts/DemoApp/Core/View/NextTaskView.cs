using DemoApp.Core.Actions;
using HSM;
using UnityEngine.EventSystems;

namespace DemoApp.Core.View
{
    public class NextTaskView : HSMViewComponent, IPointerClickHandler, IShowNextTaskMenu, IHideNextTaskMenu
    {

        public void Awake()
        {
            Deactivate();
        }
        
        public void ShowNextTaskMenu()
        {
            Activate();
        }

        public void HideNextTaskMenu()
        {
            Deactivate();
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            CreateAction<NextTaskRequestAction>().Dispatch();
        }
        
    }
}
