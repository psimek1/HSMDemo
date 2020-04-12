using DemoApp.ThingsOnShelfGame.View;
using HSM;

namespace DemoApp.ThingsOnShelfGame.States
{
    public class FinishState: HSMState
    {

        public override string Name => "Finish";
        
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            ForEachViewComponent<IFinishThingsOnShelfTask>(c => c.FinishThingsOnShelfTask());
        }

    }
}