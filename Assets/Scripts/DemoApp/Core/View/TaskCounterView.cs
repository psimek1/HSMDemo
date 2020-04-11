using DemoApp.Core.States;
using HSM;
using UnityEngine;
using UnityEngine.UI;

namespace DemoApp.Core.View
{
    public class TaskCounterView : HSMViewComponent, IEnterTask, IExitTask
    {

        [SerializeField]
        private Text text;

        private void Awake()
        {
            this.text.text = "";
        }

        public void EnterTask()
        {
            var model = GetModel<IGame>();
            this.text.text = "Úkol " + (model.CurrentTaskIndex+1) + " / " + model.TotalTaskCount;
        }

        public void ExitTask()
        {
            this.text.text = "";
        }
    }
}
