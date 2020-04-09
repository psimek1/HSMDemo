using System.Collections.Generic;
using DemoApp.ThingsOnShelfGame.Data;
using HSM;

namespace DemoApp.ThingsOnShelfGame.States
{

    public interface IThingsOnShelfGameTask
    {
        
        ThingsSet ThingsSet { get; }
        
        int SelectedThingIndex { get; }
        
    }
    
    public class ThingsOnShelfGameTaskState: HSMState, IThingsOnShelfGameTask
    {

        public ThingsSet ThingsSet { get; private set; }

        public int SelectedThingIndex { get; private set; }

        private InitState initState;
        private InputState inputState;
        private ResultState resultState;
        private FinishState finishState;
        
        public override void OnStateInit()
        {
            base.OnStateInit();

            this.name = "ThingsOnShelfGameTask";
            
            AddChildState(this.initState = new InitState());
            AddChildState(this.inputState = new InputState());
            AddChildState(this.resultState = new ResultState());
            AddChildState(this.finishState = new FinishState());
            
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            // nakonfigurování úkolu (finálně se nakonfiguruje podle obtížnosti a dalších parametrů získaných z IGame...)
            this.ThingsSet = new ThingsSet {Values = new List<int> {0,0,0,1,0,0}};
            this.SelectedThingIndex = -1;

            SwitchState(this.initState);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            this.ThingsSet = null;
            this.SelectedThingIndex = -1;
        }

        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);

            if (action is TaskReadyAction)
            {
                SwitchState(this.inputState);
                action.SetHandled();
            }
            
            else if (action is ThingSelectedAction thingSelectedAction)
            {
                this.SelectedThingIndex = thingSelectedAction.Index;
                SwitchState(this.resultState);
                action.SetHandled();                
            }
            
            else if (action is TaskResultFinishedAction)
            {
                SwitchState(this.finishState);
                action.SetHandled();
            }
        }
        
    }
}