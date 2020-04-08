using HSM;
using UnityEngine;

namespace DemoApp.Core.View
{
    public class GameView : HSMViewComponent, IInitGame
    {

        [SerializeField]
        private GameObject thingsOnShelfGame;

        [SerializeField]
        private GameObject whatIsDifferentGame;
        
        public void InitGame(Game game)
        {
            // Tady samozřejmě bude nějaké inteligentnější loadování herních modulů.
            
            this.thingsOnShelfGame.SetActive(game == Game.ThingsOnShelfGame);
            this.whatIsDifferentGame.SetActive(game == Game.WhatIsDifferentGame);
        }
        
    }
}
