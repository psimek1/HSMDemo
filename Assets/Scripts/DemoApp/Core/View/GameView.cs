using DemoApp.Core.Data;
using DemoApp.ThingsOnShelfGame.Data;
using DemoApp.WhatIsDifferentGame.Data;
using HSM;
using UnityEngine;

namespace DemoApp.Core.View
{
    public class GameView : HSMViewComponent, IStartGame, IShowNextTaskMenu
    {

        [SerializeField]
        private GameObject thingsOnShelfGame;

        [SerializeField]
        private GameObject whatIsDifferentGame;

        [SerializeField]
        private GameObject nextTask;

        private void Awake()
        {
            this.nextTask.SetActive(false);
        }

        public void StartGame(GameConfig gameConfig)
        {
            // Tady samozřejmě bude nějaké inteligentnější loadování herních modulů.
            
            this.thingsOnShelfGame.SetActive(gameConfig is ThingsOnShelfGameConfig);
            this.whatIsDifferentGame.SetActive(gameConfig is WhatIsDifferentGameConfig);
        }

        public void ShowNextTaskMenu()
        {
            this.nextTask.SetActive(true);
        }
    }
}
