using System.Collections;
using HSM;
using UnityEngine;

namespace DemoApp.ThingsOnShelfGame.View
{
    public class ThingsView : HSMViewComponent, IInitTask
    {
        public void InitTask(ThingsSet thingsSet)
        {
            StartCoroutine(InitTaskCoroutine(thingsSet));
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
    }
}
