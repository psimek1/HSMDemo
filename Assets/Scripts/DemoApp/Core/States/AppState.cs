using DemoApp.Core.Actions;
using DemoApp.Core.Data;
using DemoApp.Core.View;
using HSM;

namespace DemoApp.Core.States
{
    
    /**
     * Interface pro top-level model, obsahuje nejobecnější věci, dostupné kdykoliv
     */
    public interface IApp
    {
        
        string UserNick { get; }
        
        Game CurrentGame { get; }
        
    }
    
    /*
     * Top-level stav demo aplikace
     */
    public class AppState: HSMState, IApp
    {
        public string UserNick { get; }
        
        public Game CurrentGame { get; private set; }

        private readonly MenuState menuState;
        private readonly GameState gameState;
        
        public AppState() : base()
        {
            this.name = "DemoApp";
            
            this.UserNick = "DemoUser";

            AddChildState(this.menuState = new MenuState());
            AddChildState(this.gameState = new GameState());
            
            AddModule(new MouseSpeechStateModule());
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            // v tomto demu přeskakujeme menu (nastavujeme vybraný typ hry) a jdeme rovnou do hry:
            
            this.CurrentGame = Game.ThingsOnShelfGame;
            
            SwitchState(this.gameState);
        }

    }
}