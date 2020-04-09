using System.Collections.Generic;
using DemoApp.Core.Data;
using DemoApp.ThingsOnShelfGame.States;
using DemoApp.WhatIsDifferentGame.States;
using HSM;

namespace DemoApp.Core.States
{
    public class GameTaskState: HSMState
    {

        private readonly Dictionary<Game, HSMState> statesByGame;
        
        public GameTaskState()
        {
            this.name = "GameTask";

            this.statesByGame = new Dictionary<Game, HSMState>
            {
                [Game.ThingsOnShelfGame] = new ThingsOnShelfGameTaskState(),
                [Game.WhatIsDifferentGame] = new WhatIsDifferentGameTaskState()
            };

            foreach (var keyValuePair in this.statesByGame)
            {
                AddChildState(keyValuePair.Value);
            }
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            SwitchState(this.statesByGame[GetModel<IApp>().CurrentGame]);
        }

    }
}