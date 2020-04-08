using DemoApp.Core.Actions;
using DemoApp.Core.States;
using DemoApp.ThingsOnShelfGame.View;
using HSM;

namespace DemoApp.ThingsOnShelfGame.States
{
    public class InitState: HSMState
    {
        public InitState()
        {
            this.name = "Init";
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            // Zobrazení grafiky úkolu:

            ForEachViewComponent<IInitTask>(c => c.InitTask(GetModel<IThingsOnShelfGameTask>().ThingsSet));
            
            // Následně čekáme na TaskViewReadyAction od view
        }

        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);

            if (action is TaskViewReadyAction)
            {
                // Grafika je zobrazena, teď vygenerujeme akci pro mluvení myšáka s úvodními instrukcemi
                // (pokud se jedná o první task v řadě, což zjistíme dotazem modelu na úrovni IGame):

                if (GetModel<IGame>().IsFirstTask)
                {
                    CreateAction<PlayMouseSpeechAction>().WithSpeechId("thingsOnShelfIntro").Dispatch();
                }
                else
                {
                    CreateAction<TaskReadyAction>().Dispatch();
                }
            
                // ... a pokud myšák mluví, počkáme, až domluví (MouseSpeechFinishedAction)
                
                action.SetHandled();
            }
            
            else if (action is MouseSpeechFinishedAction)
            {
                if (((MouseSpeechFinishedAction) action).SpeechId == "thingsOnShelfIntro")
                {
                    CreateAction<TaskReadyAction>().Dispatch();
                }

                action.SetHandled();
            }
        }
    }
}