using System.Collections.Generic;
using DemoApp.Core.Actions;
using DemoApp.Core.Data;
using DemoApp.ThingsOnShelfGame.Data;
using DemoApp.WhatIsDifferentGame.Data;
using HSM;

namespace DemoApp.Core.States
{
    
    /**
     * Interface pro top-level model, obsahuje nejobecnější věci, dostupné kdykoliv
     */
    public interface IApp
    {
        
        string UserNick { get; }
        
        List<GameConfig> Games { get; }
        
        GameConfig CurrentGame { get; }
        
    }
    
    /*
     * Top-level stav demo aplikace
     */
    public class AppState: HSMState, IApp
    {
        public string UserNick { get; private set; }
        
        public List<GameConfig> Games { get; private set; }
        
        public GameConfig CurrentGame { get; private set; }

        public override string Name => "App";

        private MenuState menuState;
        private GameState gameState;
        
        public override void OnStateInit()
        {
            base.OnStateInit();
            
            this.UserNick = "DemoUser";
            
            // konfigurace všech her a jejich tasků (finálně se může např. načítat z konfiguračního souboru):

            this.Games = new List<GameConfig>()
            {
                new ThingsOnShelfGameConfig()
                {
                    Tasks = new List<GameTaskConfig>()
                    {
                        new ThingsOnShelfGameTaskConfig {Values = new List<int> {0, 0, 0, 1, 0, 0}},
                        new ThingsOnShelfGameTaskConfig {Values = new List<int> {0, 1, 0, 0, 0, 0}},
                        new ThingsOnShelfGameTaskConfig {Values = new List<int> {0, 0, 0, 0, 0, 1}},
                        new ThingsOnShelfGameTaskConfig {Values = new List<int> {0, 0, 1, 0, 0, 0}},
                    }
                },
                new WhatIsDifferentGameConfig()
                {
                    // todo
                }
            };
        }

        protected override void AddChildStates()
        {
            AddChildState(this.menuState = new MenuState());
            AddChildState(this.gameState = new GameState());
        }

        protected override void AddModules()
        {
            AddModule(new MouseSpeechStateModule());
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            SwitchState(this.menuState);
        }

        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);

            if (action is GameSelectedAction gameSelectedAction)
            {
                this.CurrentGame = this.Games[gameSelectedAction.Index];
                SwitchState(this.gameState);
                action.SetHandled();
            }
        }
        
    }
    
}