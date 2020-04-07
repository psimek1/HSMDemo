using HSM;

namespace DemoApp.Core
{

    public interface IGame
    {
        bool IsFirstTask { get; }
    }

    /**
     * Na úrovni tohoto stavu se řeší spouštění úkolů.
     * Celá tato třída může být v jiné konfiguraci nahrazena jinou třídou, která bude řešit jiný průchod úkoly
     * - např. sekvence úkolů versus výběr úkolu z menu
     * Vždy však musí implementovat IGame pro data, která jsou všem verzím společná
     * - viz např. IsFirstTask, díky kterému task zjistí, zda je první v řadě a přizpůsobí se tomu (myšák říká úvodní instrukce pouze jednou)
     */
    public class GameState : HSMState, IGame
    {

        private GameMenuState gameMenuState;
        private GameTaskState gameTaskState;

        public GameState() : base()
        {

            this.name = "Game";

            AddChildState(this.gameMenuState = new GameMenuState());
            AddChildState(this.gameTaskState = new GameTaskState());

        }

        public bool IsFirstTask => true; // todo

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            SwitchState(this.gameTaskState);
        }
    }
}
