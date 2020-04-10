using DemoApp.Core.Actions;
using DemoApp.Core.Data;
using DemoApp.Core.View;
using HSM;

namespace DemoApp.Core.States
{

    public interface IGame
    {
      
        int TotalTaskCount { get; }
        
        int CurrentTaskIndex { get; }
        
        GameTaskConfig CurrentGameTask { get; }
        
        bool IsFirstTask { get; }
        
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

        public override string Name => "Game";
        
        public int TotalTaskCount => GetModel<IApp>().CurrentGame.Tasks.Count;
        
        public int CurrentTaskIndex { get; private set; }

        public GameTaskConfig CurrentGameTask => GetModel<IApp>().CurrentGame.Tasks[this.CurrentTaskIndex];
        
        public bool IsFirstTask { get; private set; }
        
        private GameMenuState gameMenuState;
        private GameTaskState gameTaskState;
        private GameNextTaskState gameNextTaskState;

        protected override void AddChildStates()
        {
            AddChildState(this.gameMenuState = new GameMenuState());
            AddChildState(this.gameTaskState = new GameTaskState());
            AddChildState(this.gameNextTaskState = new GameNextTaskState());
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            ForEachViewComponent<IStartGame>(c => c.StartGame(GetModel<IApp>().CurrentGame));

            // v tomto demu přeskakujeme menu (resp. logiku výběru tasku) a jdeme rovnou na task:

            this.IsFirstTask = true;
            this.CurrentTaskIndex = 0;
            SwitchState(this.gameTaskState);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            
            ForEachViewComponent<IEndGame>(c => c.EndGame());
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
                this.CurrentTaskIndex++;
                SwitchState(this.gameTaskState);
                action.SetHandled();    
            }
            
        }
        
    }
}
