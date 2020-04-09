using DemoApp.Core.Actions;
using DemoApp.Core.View;
using HSM;

namespace DemoApp.Core.States
{

    public interface IGame
    {
        bool IsFirstTask { get; }
    }

    /**
     * Na úrovni tohoto stavu se řeší spouštění úkolů.
     * Celá tato třída může být v jiné konfiguraci nahrazena jinou třídou, která bude řešit alternativní průchod úkoly
     * - např. sekvence úkolů versus výběr úkolu z menu
     * Vždy však musí implementovat IGame pro data, která jsou všem verzím společná
     * - viz např. IsFirstTask, díky kterému task zjistí, zda je první v řadě, a přizpůsobí se tomu (myšák říká úvodní instrukce pouze jednou)
     */
    public class GameState : HSMState, IGame
    {

        public bool IsFirstTask { get; private set; }
        
        private readonly GameMenuState gameMenuState;
        private readonly GameTaskState gameTaskState;
        private readonly GameNextTaskState gameNextTaskState;
        

        public GameState() : base()
        {

            this.name = "Game";

            AddChildState(this.gameMenuState = new GameMenuState());
            AddChildState(this.gameTaskState = new GameTaskState());

        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            ForEachViewComponent<IInitGame>(c => c.InitGame(GetModel<IApp>().CurrentGame));

            // v tomto demu přeskakujeme menu (resp. logiku výběru tasku) a jdeme rovnou na task:

            this.IsFirstTask = true;
            
            SwitchState(this.gameTaskState);
        }
        
        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);

            if (action is TaskFinishedAction taskFinishedAction)
            {
                // todo
                
                action.SetHandled();
            }
        }
        
    }
}
