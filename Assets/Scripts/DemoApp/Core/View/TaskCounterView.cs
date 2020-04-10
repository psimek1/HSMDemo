using DemoApp.Core.States;
using HSM;
using UnityEngine;
using UnityEngine.UI;

namespace DemoApp.Core.View
{
    public class TaskCounterView : HSMViewComponent, IStartTask, IEndTask
    {

        [SerializeField]
        private Text text;

        private void Awake()
        {
            this.text.text = "";
        }

        public void StartTask()
        {
            var model = GetModel<IGame>();
            this.text.text = "Úkol " + (model.CurrentTaskIndex+1) + " / " + model.TotalTaskCount;
        }

        public void EndTask()
        {
            this.text.text = "";
        }
    }
}
