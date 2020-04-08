using HSM;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DemoApp.ThingsOnShelfGame.View
{
    public class ThingImageView : HSMViewComponent, IInitTask, IEnableInput, IDisableInput, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {

        [SerializeField]
        private int index;

        [SerializeField]
        private Color32[] colors;

        [SerializeField]
        private Image fill;

        [SerializeField] 
        private GameObject border;

        private bool isInputEnabled;

        public void OnEnable()
        {
            this.border.SetActive(false);
        }

        public void InitTask(ThingsSet thingsSet)
        {
            fill.color = this.colors[thingsSet.Values[this.index]];
        }
        
        public void EnableInput()
        {
            this.isInputEnabled = true;
        }

        public void DisableInput()
        {
            this.border.SetActive(false);
            this.isInputEnabled = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (this.isInputEnabled)
            {
                this.border.SetActive(true);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this.border.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (this.isInputEnabled)
            {
                CreateAction<ThingSelectedAction>().WithIndex(this.index).Dispatch();
            }
        }

    }
}
