using System.Collections.Generic;
using DemoApp.Core.Actions;
using DemoApp.Core.Data;
using DemoApp.Core.View;
using HSM;

namespace DemoApp.Core.States
{
    public class GameTaskState: HSMState
    {
        
        public override string Name => "GameTask";

        private Dictionary<GameConfig, HSMState> childStatesByGameConfig;
        
        protected override void AddChildStates()
        {
            // podstavy vytvoříme pro všechny typy her podle configu:
            
            this.childStatesByGameConfig = new Dictionary<GameConfig, HSMState>();
            
            GetModel<IApp>().Games.ForEach(config =>
            {
                AddChildState(this.childStatesByGameConfig[config] = config.CreateTaskState());
            });
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            ForEachViewComponent<IEnterTask>(c => c.EnterTask());
            
            SwitchState(this.childStatesByGameConfig[GetModel<IApp>().CurrentGame]);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            ForEachViewComponent<IExitTask>(c => c.ExitTask());
            
            // Pokud mluví myšák (což se může stát při okamžitém vyskočení z tasku pomocí Back nebo Home), tak ho stopneme:

            CreateAction<StopMouseSpeechAction>().Dispatch();
        }

        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);

            if (action is BackAction)
            {
                CreateAction<ExitTaskAction>().Dispatch();
                
                action.SetHandled();
            }
            
        }
        
    }
}