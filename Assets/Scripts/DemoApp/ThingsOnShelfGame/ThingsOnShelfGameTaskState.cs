using HSM;

namespace DemoApp.ThingsOnShelfGame
{
    public class ThingsOnShelfGameTaskState: HSMState
    {

        private InitState initState;
        
        public ThingsOnShelfGameTaskState()
        {

            this.name = "ThingsOnShelfGameTask";
            
            AddChildState(this.initState = new InitState());
            
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            SwitchState(this.initState);
        }
    }
}