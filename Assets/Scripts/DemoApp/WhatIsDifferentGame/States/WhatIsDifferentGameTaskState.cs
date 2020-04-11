using DemoApp.Core.Actions;
using DemoApp.WhatIsDifferentGame.Actions;
using DemoApp.WhatIsDifferentGame.View;
using HSM;

namespace DemoApp.WhatIsDifferentGame.States
{
    
    /**
     * Tato hra není implementována, toto je tedy minimální podoba této třídy - bez jakékoliv interaktivity
     * (pouze se na chvíli zobrazí upozornění) se posílá TaskFinishedAction simulující úspěšné provedení úkolu.
     */
    
    public class WhatIsDifferentGameTaskState: HSMState
    {
        public override string Name => "WhatIsDifferentGameTask";

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            ForEachViewComponent<IRunTaskTemp>(c => c.RunTaskTemp());
        }

        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);

            if (action is TaskViewFinishedAction)
            {
                CreateAction<TaskFinishedAction>().WithSuccess().Dispatch();
                
                action.SetHandled();
            }
        }
        
    }
    
}