using DemoApp.ThingsOnShelfGame.View;
using HSM;
using UnityEngine;

namespace DemoApp.ThingsOnShelfGame.States
{
    public class InputState: HSMState
    {
        public InputState()
        {
            this.name = "Input";
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            ForEachViewComponent<IEnableInput>(c => c.EnableInput());
        }

        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);

            if (action is ThingSelectedAction)
            {
                int index = (action as ThingSelectedAction).Index;
                Debug.Log(index);
                
                ForEachViewComponent<IDisableInput>(c => c.DisableInput());    
                action.SetHandled();
            }
        }
    }
}