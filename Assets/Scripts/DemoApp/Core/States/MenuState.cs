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
            
            ForEachViewComponent<IShowMenu>(c => c.ShowMenu());
        }
        
        public override void OnStateExit()
        {
            base.OnStateEnter();
            
            ForEachViewComponent<IHideMenu>(c => c.HideMenu());
        }
        
    }
}