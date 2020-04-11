using System.Collections;
using DemoApp.Core.View;
using DemoApp.ThingsOnShelfGame.Data;
using HSM;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DemoApp.ThingsOnShelfGame.View
{
    public class ThingImageView : HSMViewComponent, IInitThingsOnShelfTask, IEnableInput, IDisableInput, IShowSolution, IFinishThingsOnShelfTask, IExitTask, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
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
            
            this.isInputEnabled = false;
        }

        public void InitThingsOnShelfTask(ThingsOnShelfGameTaskConfig thingsOnShelfGameTaskConfig)
        {
            fill.color = this.colors[thingsOnShelfGameTaskConfig.Values[this.index]];
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

        public void ShowSolution(int correctThingIndex)
        {
            if (this.index == correctThingIndex)
            {
                StartCoroutine(HighlightCoroutine());
            }
        }
        
        public void FinishThingsOnShelfTask()
        {
            StopAllCoroutines();
            this.border.SetActive(false);
        }
       
        public void ExitTask()
        {
            StopAllCoroutines();
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

        private IEnumerator HighlightCoroutine()
        {
            while (true)
            {
                this.border.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                this.border.SetActive(false);
                yield return new WaitForSeconds(0.1f);
            }
        }

    }
}
