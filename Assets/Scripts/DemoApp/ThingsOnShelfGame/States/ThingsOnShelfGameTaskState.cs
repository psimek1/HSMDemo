using System.Collections.Generic;
using HSM;

namespace DemoApp.ThingsOnShelfGame.States
{

    public interface IThingsOnShelfGameTask
    {
        
        ThingsSet ThingsSet { get; }
        
    }
    
    public class ThingsOnShelfGameTaskState: HSMState, IThingsOnShelfGameTask
    {

        public ThingsSet ThingsSet { get; private set; }
        
        private readonly InitState initState;
        private readonly InputState inputState;
        private readonly SuccessState successState;
        private readonly FailState failState;
        
        public ThingsOnShelfGameTaskState()
        {

            this.name = "ThingsOnShelfGameTask";
            
            AddChildState(this.initState = new InitState());
            AddChildState(this.inputState = new InputState());
            AddChildState(this.successState = new SuccessState());
            AddChildState(this.failState = new FailState());
            
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            // nakonfigurování úkolu (finálně se nakonfiguruje podle obtížnosti a dalších parametrů získaných z IGame...)
            this.ThingsSet = new ThingsSet {Values = new List<int> {0,0,0,1,0,0}};

            SwitchState(this.initState);
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
                if (this.ThingsSet.Values[thingSelectedAction.Index] == 1)
                {
                    SwitchState(this.successState);
                }
                else
                {
                    SwitchState(this.failState);
                }
                
                action.SetHandled();                
            }
        }
        
    }
}