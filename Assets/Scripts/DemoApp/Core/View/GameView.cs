using DemoApp.Core.Data;
using HSM;

namespace DemoApp.Core.View
{
    public class GameView : HSMViewComponent, IStartGame, IEndGame
    {

        public void Awake()
        {
            Deactivate();
        }

        public void StartGame(GameConfig gameConfig)
        {
            Activate();
        }

        public void EndGame()
        {
            Deactivate();
        }
        
    }
    
}
