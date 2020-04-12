using HSM;

namespace DemoApp.Core.View
{
    public class GameView : HSMViewComponent, IEnterGame, IExitGame
    {

        public void Awake()
        {
            Deactivate();
        }

        public void EnterGame()
        {
            Activate();
        }

        public void ExitGame()
        {
            Deactivate();
        }
        
    }
    
}
