using System.Collections;
using DemoApp.Core.View;
using DemoApp.WhatIsDifferentGame.Actions;
using HSM;
using UnityEngine;

namespace DemoApp.WhatIsDifferentGame.View
{
    public class WhatIsDifferentGameTaskView : HSMViewComponent, IRunTaskTemp, IExitTask
    {
        
        public void RunTaskTemp()
        {
            StartCoroutine(RunTaskCoroutine());
        }

        private IEnumerator RunTaskCoroutine()
        {
            yield return new WaitForSeconds(1);
            
            CreateAction<TaskViewFinishedAction>().Dispatch();
        }

        public void ExitTask()
        {
            StopAllCoroutines();
        }
            
    }
    
}
