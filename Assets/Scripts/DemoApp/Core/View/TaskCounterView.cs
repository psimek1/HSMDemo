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
            this.text.text = "Úkol";
        }

        public void EndTask()
        {
            this.text.text = "";
        }
    }
}
