using System;
using DemoApp.Core.Data;
using HSM;
using UnityEngine;

namespace DemoApp.Core.View
{
    public class GameView : HSMViewComponent, IInitGame, IShowNextTaskMenu
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

        public void InitGame(GameType gameType)
        {
            // Tady samozřejmě bude nějaké inteligentnější loadování herních modulů.
            
            this.thingsOnShelfGame.SetActive(gameType == GameType.ThingsOnShelfGame);
            this.whatIsDifferentGame.SetActive(gameType == GameType.WhatIsDifferentGame);
        }

        public void ShowNextTaskMenu()
        {
            this.nextTask.SetActive(true);
        }
    }
}
