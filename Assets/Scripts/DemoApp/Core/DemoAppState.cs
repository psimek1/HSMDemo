using System;
using DemoApp.Core.Actions;
using HSM;

namespace DemoApp.Core
{
    /*
     * Top-level stav demo aplikace
     */
    public class DemoAppState: HSMState, IDemoApp
    {
        public string UserNick { get; private set; }

        private readonly MenuState menuState;
        private readonly GameState gameState;
        
        public DemoAppState() : base()
        {
            this.name = "DemoApp";
            
            this.UserNick = "DemoUser";
            
            AddChildState(this.menuState = new MenuState());
            AddChildState(this.gameState = new GameState());
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            SwitchState(this.menuState);
            CreateAction<HomeAction>().Dispatch();
        }
    }
}