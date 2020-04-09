using DemoApp.Core.Actions;
using DemoApp.Core.View;
using HSM;

namespace DemoApp.Core.States
{

    public interface IGame
    {
        bool IsFirstTask { get; }
        
        int TotalTaskCount { get; }
        
        int CurrentTaskIndex { get; }
    }

    /**
     * Na úrovni tohoto stavu se řeší spouštění úkolů.
     * Celá tato třída může být v jiné konfiguraci nahrazena jinou třídou, která bude řešit alternativní průchod úkoly
     * - např. sekvence úkolů versus výběr úkolu z menu
     * Vždy však musí implementovat IGame pro data, která jsou všem verzím společná
     * - viz např. IsFirstTask, díky kterému task zjistí, zda je první, a přizpůsobí se tomu (myšák říká úvodní instrukce pouze jednou)
     */
    public class GameState : HSMState, IGame
    {

        public bool IsFirstTask { get; private set; }
        public int TotalTaskCount { get; private set; }
        public int CurrentTaskIndex { get; private set; }

        private GameMenuState gameMenuState;
        private GameTaskState gameTaskState;
        private GameNextTaskState gameNextTaskState;
        

        public override void OnStateInit()
        {
            base.OnStateInit();

            this.name = "Game";

            AddChildState(this.gameMenuState = new GameMenuState());
            AddChildState(this.gameTaskState = new GameTaskState());
            AddChildState(this.gameNextTaskState = new GameNextTaskState());
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            ForEachViewComponent<IInitGame>(c => c.InitGame(GetModel<IApp>().CurrentGameType));

            // v tomto demu přeskakujeme menu (resp. logiku výběru tasku) a jdeme rovnou na task:

            this.IsFirstTask = true;
            this.TotalTaskCount = 10;
            this.CurrentTaskIndex = 0;
            
            SwitchState(this.gameTaskState);
        }
        
        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);

            if (action is TaskFinishedAction taskFinishedAction)
            {
                SwitchState(this.gameNextTaskState);
                
                action.SetHandled();
            }
            
            else if (action is NextTaskRequestAction)
            {
                this.IsFirstTask = false;
                
                SwitchState(this.gameTaskState);
                
                action.SetHandled();    
            }
            
        }
        
    }
}
