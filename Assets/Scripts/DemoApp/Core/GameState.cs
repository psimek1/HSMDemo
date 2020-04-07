using HSM;

namespace DemoApp.Core
{
    public class GameState: HSMState
    {

        private GameMenuState gameMenuState;
        private GameTaskState gameTaskState;
        
        public GameState() : base()
        {
            
            this.name = "Game";
            
            AddChildState(this.gameMenuState = new GameMenuState());
            AddChildState(this.gameTaskState = new GameTaskState());
            
        }
    }
}