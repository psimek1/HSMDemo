using HSM;

namespace DemoApp.Core.States
{
    public class MenuState: HSMState
    {
        public override void OnStateInit()
        {
            base.OnStateInit();

            this.name = "Menu";
        }
    }
}