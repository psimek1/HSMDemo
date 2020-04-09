using HSM;

namespace DemoApp.Core.States
{
    public class GameMenuState: HSMState
    {
        public override void OnStateInit()
        {
            base.OnStateInit();
            
            this.name = "GameMenu";
        }
    }
}