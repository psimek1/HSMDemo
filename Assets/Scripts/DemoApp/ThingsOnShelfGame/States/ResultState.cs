using DemoApp.Core.Actions;
using DemoApp.Core.Data;
using DemoApp.ThingsOnShelfGame.View;
using HSM;

namespace DemoApp.ThingsOnShelfGame.States
{
    public class ResultState: HSMState
    {

        private MouseSpeech successSpeech;

        private MouseSpeech failSpeech;
        
        public override void OnStateInit()
        {
            base.OnStateInit();
            
            this.name = "Result";

            this.successSpeech = new MouseSpeech("Výborně!");
            this.failSpeech = new MouseSpeech("To nebylo správně! Takhle to mělo být.");
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            int correctThingIndex = GetModel<IThingsOnShelfGameTask>().ThingsSet.CorrectThingIndex;
            if (GetModel<IThingsOnShelfGameTask>().SelectedThingIndex == correctThingIndex)
            {
                // success
                CreateAction<PlayMouseSpeechAction>().WithSpeech(this.successSpeech).Dispatch();
            }
            else
            {
                // fail
                CreateAction<PlayMouseSpeechAction>().WithSpeech(this.failSpeech).Dispatch();
                ForEachViewComponent<IShowSolution>(c => c.ShowSolution(correctThingIndex));
            }
        }

        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);

            if (action is MouseSpeechFinishedAction)
            {
                CreateAction<TaskResultFinishedAction>().Dispatch();
                
                action.SetHandled();
            }
        }
        
    }
    
}