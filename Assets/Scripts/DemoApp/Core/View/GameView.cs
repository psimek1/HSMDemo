using DemoApp.Core.Data;
using HSM;

namespace DemoApp.Core.View
{
    public class GameView : HSMViewComponent, IEnterGame, IExitGame
    {

        public void Awake()
        {
            Deactivate();
        }

        public void EnterGame(GameConfig gameConfig)
        {
            Activate();
        }

        public void ExitGame()
        {
            Deactivate();
        }
        
    }
    
}
