using System.Collections;
using DemoApp.Core.Actions;
using DemoApp.ThingsOnShelfGame.Data;
using HSM;
using UnityEngine;

namespace DemoApp.ThingsOnShelfGame.View
{
    public class ThingsView : HSMViewComponent, IInitThingsOnShelfTask, IFinishThingsOnShelfTask
    {
        public void InitThingsOnShelfTask(ThingsOnShelfGameTaskConfig thingsOnShelfGameTaskConfig)
        {
            StartCoroutine(InitTaskCoroutine(thingsOnShelfGameTaskConfig));
        }

        public void FinishThingsOnShelfTask()
        {
            StartCoroutine(FinishTaskCoroutine());
        }
        
        private IEnumerator InitTaskCoroutine(ThingsOnShelfGameTaskConfig thingsOnShelfGameTaskConfig)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }

            for (int i = 0; i < thingsOnShelfGameTaskConfig.Values.Count; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.1f);
            }
            
            CreateAction<TaskViewReadyAction>().Dispatch();
        }

        private IEnumerator FinishTaskCoroutine()
        {
            for (int i = this.transform.childCount-1; i >= 0; i--)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
                yield return new WaitForSeconds(0.1f);
            }
            
            CreateAction<TaskViewFinishedAction>().Dispatch();
        }

    }
}
