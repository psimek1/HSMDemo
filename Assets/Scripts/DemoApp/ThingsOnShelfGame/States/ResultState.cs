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

        public override string Name => "Result";
        
        public override void OnStateInit()
        {
            base.OnStateInit();
            
            this.successSpeech = new MouseSpeech("Výborně!");
            this.failSpeech = new MouseSpeech("To nebylo správně! Takhle to mělo být.");
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            int correctThingIndex = GetModel<IThingsOnShelfGameTask>().ThingsOnShelfGameTaskConfig.CorrectThingIndex;
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