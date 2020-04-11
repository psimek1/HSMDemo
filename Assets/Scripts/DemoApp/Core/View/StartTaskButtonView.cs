using DemoApp.Core.Actions;
using HSM;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DemoApp.Core.View
{
    public class StartTaskButtonView : HSMViewComponent, IShowGameMenu, IHideGameMenu, IPointerClickHandler
    {

        [SerializeField]
        private Text text;
        
        private int index;

        public void Awake()
        {
            Deactivate();
            
            this.index = IndexInParent;
            this.text.text = "Úkol " + (this.index + 1);
        }
        
        public void ShowGameMenu()
        {
            Activate();
        }

        public void HideGameMenu()
        {
            Deactivate();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            CreateAction<TaskSelectedAction>().WithIndex(this.index).Dispatch();
        }
        
    }
    
}
