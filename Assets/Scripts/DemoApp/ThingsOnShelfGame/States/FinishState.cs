using DemoApp.Core.Actions;
using DemoApp.ThingsOnShelfGame.View;
using HSM;

namespace DemoApp.ThingsOnShelfGame.States
{
    public class FinishState: HSMState
    {
        public FinishState()
        {
            this.name = "Finish";
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            ForEachViewComponent<IFinishTask>(c => c.FinishTask());
        }

        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);
            
            if (action is TaskViewFinishedAction)
            {
                CreateAction<TaskFinishedAction>().Dispatch();
                
                action.SetHandled();
            }
        }
    }
}