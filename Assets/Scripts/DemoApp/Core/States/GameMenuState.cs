using DemoApp.Core.View;
using HSM;

namespace DemoApp.Core.States
{
    public class GameMenuState: HSMState
    {
        public override string Name => "GameMenu";

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            ForEachViewComponent<IEnterGameMenu>(c => c.EnterGameMenu());
        }
        
        public override void OnStateExit()
        {
            base.OnStateEnter();
            
            ForEachViewComponent<IExitGameMenu>(c => c.ExitGameMenu());
        }
    }
}