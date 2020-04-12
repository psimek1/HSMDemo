using DemoApp.Core.Actions;
using DemoApp.Core.States;
using HSM;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DemoApp.Core.View
{
    public class MenuItemView : HSMViewComponent, IPointerClickHandler
    {

        [SerializeField]
        private Text text;

        private int index;

        public void Awake()
        {
            this.index = IndexInParent;
            this.text.text = GetModel<IApp>().Games[this.index].Name;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            CreateAction<GameSelectedAction>().WithIndex(this.index).Dispatch();
        }
        
    }
}
