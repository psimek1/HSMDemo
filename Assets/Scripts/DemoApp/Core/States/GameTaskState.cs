using System.Collections.Generic;
using DemoApp.Core.Data;
using DemoApp.Core.View;
using DemoApp.ThingsOnShelfGame.States;
using DemoApp.WhatIsDifferentGame.States;
using HSM;

namespace DemoApp.Core.States
{
    public class GameTaskState: HSMState
    {

        private Dictionary<GameType, HSMState> statesByGame;
        
        public override void OnStateInit()
        {
            base.OnStateInit();
            this.name = "GameTask";

            this.statesByGame = new Dictionary<GameType, HSMState>
            {
                [GameType.ThingsOnShelfGame] = new ThingsOnShelfGameTaskState(),
                [GameType.WhatIsDifferentGame] = new WhatIsDifferentGameTaskState()
            };

            foreach (var keyValuePair in this.statesByGame)
            {
                AddChildState(keyValuePair.Value);
            }
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            ForEachViewComponent<IStartTask>(c => c.StartTask());
            
            SwitchState(this.statesByGame[GetModel<IApp>().CurrentGameType]);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            ForEachViewComponent<IEndTask>(c => c.EndTask());
        }
    }
}