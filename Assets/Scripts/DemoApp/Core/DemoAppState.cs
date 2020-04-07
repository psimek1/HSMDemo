using DemoApp.Core.Actions;
using DemoApp.Core.View;
using HSM;

namespace DemoApp.Core
{
    
    /**
     * Interface pro top-level model, obsahuje nejobecnější věci, dostupné kdykoliv
     */
    public interface IDemoApp
    {
        
        string UserNick { get; }
        
    }
    
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