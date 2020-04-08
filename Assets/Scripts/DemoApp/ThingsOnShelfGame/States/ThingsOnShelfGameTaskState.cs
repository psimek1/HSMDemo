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
        
        private InitState initState;
        
        public ThingsOnShelfGameTaskState()
        {

            this.name = "ThingsOnShelfGameTask";
            
            AddChildState(this.initState = new InitState());
            
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            // nakonfigurování úkolu (finálně se nakonfiguruje podle obtížnosti a dalších parametrů získaných z IGame...)
            this.ThingsSet = new ThingsSet {Values = new List<int> {0,0,0,1,0,0}};

            SwitchState(this.initState);
        }

        
    }
}