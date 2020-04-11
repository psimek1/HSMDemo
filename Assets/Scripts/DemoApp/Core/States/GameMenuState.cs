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
            
            ForEachViewComponent<IShowGameMenu>(c => c.ShowGameMenu());
        }
        
        public override void OnStateExit()
        {
            base.OnStateEnter();
            
            ForEachViewComponent<IHideGameMenu>(c => c.HideGameMenu());
        }
    }
}