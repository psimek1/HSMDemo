using DemoApp.Core.View;
using HSM;

namespace DemoApp.Core.States
{
    public class MenuState: HSMState
    {
        
        public override string Name => "Menu";

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            ForEachViewComponent<IEnterMenu>(c => c.EnterMenu());
        }
        
        public override void OnStateExit()
        {
            base.OnStateEnter();
            
            ForEachViewComponent<IExitMenu>(c => c.ExitMenu());
        }
        
    }
}