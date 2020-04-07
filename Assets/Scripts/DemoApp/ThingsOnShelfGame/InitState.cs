using DemoApp.Core;
using DemoApp.Core.Actions;
using HSM;

namespace DemoApp.ThingsOnShelfGame
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
            
            // Tady se (ve vzájemné komunikaci s view) provedou asynchronní operace:
            
            // - zobrazení grafiky úkolu:
            // todo
            
            // - vygenerování akce pro mluvení myšáka s úvodními instrukcemi (pokud se jedná o první task v řadě, což zjistíme dotazem nadřazenému modelu):

            if (GetModel<IGame>().IsFirstTask)
            {
                CreateAction<PlayMouseSpeechAction>().WithSpeechId("thingsOnShelfIntro").Dispatch();
            }
            else
            {
                CreateAction<TaskReadyAction>().Dispatch();
            }
            
            // - a pokud myšák mluví, počkáme, až domluví (akce MouseSpeechFinished)
        }

        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);

            if (action is MouseSpeechFinishedAction)
            {
                if (((MouseSpeechFinishedAction) action).SpeechId == "thingsOnShelfIntro")
                {
                    CreateAction<TaskReadyAction>().Dispatch();
                }

                action.Handled = true;
            }
        }
    }
}