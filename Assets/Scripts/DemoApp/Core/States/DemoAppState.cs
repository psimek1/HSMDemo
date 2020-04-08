using DemoApp.Core.Actions;
using DemoApp.Core.View;
using HSM;

namespace DemoApp.Core.States
{
    
    /**
     * Interface pro top-level model, obsahuje nejobecnější věci, dostupné kdykoliv
     */
    public interface IDemoApp
    {
        
        string UserNick { get; }
        
        Game CurrentGame { get; }
        
    }
    
    /*
     * Top-level stav demo aplikace
     */
    public class DemoAppState: HSMState, IDemoApp
    {
        public string UserNick { get; }
        
        public Game CurrentGame { get; private set; }

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
            
            // v tomto demu přeskakujeme menu a jdeme rovnou do hry:
            
            this.CurrentGame = Game.ThingsOnShelfGame;
            
            SwitchState(this.gameState);
        }

        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);

            if (action is PlayMouseSpeechAction)
            {
                ForEachViewComponent<IPlayMouseSpeech>(c => c.PlayMouseSpeech((action as PlayMouseSpeechAction).SpeechId));
            }
        }
    }
}