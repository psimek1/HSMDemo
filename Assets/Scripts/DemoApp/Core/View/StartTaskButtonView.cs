using DemoApp.Core.Actions;
using DemoApp.Core.States;
using HSM;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DemoApp.Core.View
{
    public class StartTaskButtonView : HSMViewComponent, IEnterGameMenu, IExitGameMenu, IPointerClickHandler
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
        
        public void EnterGameMenu()
        {
            if (this.index < GetModel<IApp>().CurrentGame.Tasks.Count)
            {
                Activate();
            }
        }

        public void ExitGameMenu()
        {
            Deactivate();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            CreateAction<TaskSelectedAction>().WithIndex(this.index).Dispatch();
        }
        
    }
    
}
