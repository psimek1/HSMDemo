using DemoApp.Core.Data;
using DemoApp.ThingsOnShelfGame.Data;
using DemoApp.WhatIsDifferentGame.Data;
using HSM;
using UnityEngine;

namespace DemoApp.Core.View
{
    public class GameTaskView : HSMViewComponent, IEnterGame, IEnterTask, IExitTask
    {

        [SerializeField]
        private GameObject thingsOnShelfGame;

        [SerializeField]
        private GameObject whatIsDifferentGame;

        public void Awake()
        {
            Deactivate();
        }

        public void EnterGame(GameConfig gameConfig)
        {
            // Tady samozřejmě bude nějaké inteligentnější loadování herních modulů.
            
            this.thingsOnShelfGame.SetActive(gameConfig is ThingsOnShelfGameConfig);
            this.whatIsDifferentGame.SetActive(gameConfig is WhatIsDifferentGameConfig);
        }

        public void EnterTask()
        {
            Activate();
        }

        public void ExitTask()
        {
            Deactivate();
        }
        
    }
    
}
