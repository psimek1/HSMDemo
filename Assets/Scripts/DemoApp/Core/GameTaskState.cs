﻿using DemoApp.ThingsOnShelfGame;
using HSM;

namespace DemoApp.Core
{
    public class GameTaskState: HSMState
    {

        private ThingsOnShelfGameTaskState thingsOnShelfGameTaskState;
        
        public GameTaskState()
        {
            this.name = "GameTask";
            
            AddChildState(this.thingsOnShelfGameTaskState = new ThingsOnShelfGameTaskState());
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            // rovnou přepínáme na konkrétní typ úkolu, finálně tady pochopitelně bude výběr příslušného úkolu:
            SwitchState(this.thingsOnShelfGameTaskState);
        }
        
    }
}