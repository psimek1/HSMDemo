using DemoApp.Core.Actions;
using DemoApp.Core.Data;
using DemoApp.Core.States;
using DemoApp.ThingsOnShelfGame.View;
using HSM;

namespace DemoApp.ThingsOnShelfGame.States
{
    public class InitState: HSMState
    {

        private MouseSpeech introSpeech;
        
        public override string Name => "Init";
        
        public override void OnStateInit()
        {
            base.OnStateInit();
            
            this.introSpeech = new MouseSpeech("Dokážeš najít předmět, který nepatří mezi ostatní?");
        }
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            // Zobrazení grafiky úkolu:

            ForEachViewComponent<IInitThingsOnShelfTask>(c => c.InitThingsOnShelfTask(GetModel<IThingsOnShelfGameTask>().CurrentGameTask));
            
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
                    CreateAction<PlayMouseSpeechAction>().WithSpeech(this.introSpeech).Dispatch();
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
                if (((MouseSpeechFinishedAction) action).Speech == this.introSpeech)
                {
                    CreateAction<TaskReadyAction>().Dispatch();
                }

                action.SetHandled();
            }
            
        }
    }
}