using DemoApp.Core.Data;
using DemoApp.ThingsOnShelfGame.Data;
using DemoApp.WhatIsDifferentGame.Data;
using HSM;
using UnityEngine;

namespace DemoApp.Core.View
{
    public class GameTaskView : HSMViewComponent, IStartGame, IStartTask, IEndTask
    {

        [SerializeField]
        private GameObject thingsOnShelfGame;

        [SerializeField]
        private GameObject whatIsDifferentGame;

        public void Awake()
        {
            Deactivate();
        }

        public void StartGame(GameConfig gameConfig)
        {
            // Tady samozřejmě bude nějaké inteligentnější loadování herních modulů.
            
            this.thingsOnShelfGame.SetActive(gameConfig is ThingsOnShelfGameConfig);
            this.whatIsDifferentGame.SetActive(gameConfig is WhatIsDifferentGameConfig);
        }

        public void StartTask()
        {
            Activate();
        }

        public void EndTask()
        {
            Deactivate();
        }
        
    }
    
}
