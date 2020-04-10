using System.Collections.Generic;
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

            ForEachViewComponent<IStartTask>(c => c.StartTask());
            
            SwitchState(this.childStatesByGameConfig[GetModel<IApp>().CurrentGame]);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            ForEachViewComponent<IEndTask>(c => c.EndTask());
        }
    }
}