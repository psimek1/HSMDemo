using DemoApp.ThingsOnShelfGame.Actions;
using DemoApp.ThingsOnShelfGame.View;
using HSM;
using UnityEngine;

namespace DemoApp.ThingsOnShelfGame.States
{
    public class InputState: HSMState
    {
        public override string Name => "Input";

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
                ForEachViewComponent<IDisableInput>(c => c.DisableInput());
            }
        }
    }
}