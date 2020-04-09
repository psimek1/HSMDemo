using System.Collections;
using DemoApp.Core.Actions;
using DemoApp.ThingsOnShelfGame.Data;
using HSM;
using UnityEngine;

namespace DemoApp.ThingsOnShelfGame.View
{
    public class ThingsView : HSMViewComponent, IInitTask, IFinishTask
    {
        public void InitTask(ThingsSet thingsSet)
        {
            StartCoroutine(InitTaskCoroutine(thingsSet));
        }

        public void FinishTask()
        {
            StartCoroutine(FinishTaskCoroutine());
        }
        
        private IEnumerator InitTaskCoroutine(ThingsSet thingsSet)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }

            for (int i = 0; i < thingsSet.Values.Count; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.2f);
            }
            
            CreateAction<TaskViewReadyAction>().Dispatch();
        }

        private IEnumerator FinishTaskCoroutine()
        {
            for (int i = this.transform.childCount-1; i >= 0; i--)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
                yield return new WaitForSeconds(0.2f);
            }
            
            CreateAction<TaskViewFinishedAction>().Dispatch();
        }

    }
}
