using DemoApp.Core.Data;
using DemoApp.Core.States;
using HSM;
using UnityEngine;
using UnityEngine.UI;

namespace DemoApp.Core.View
{
    public class GameTitleView : HSMViewComponent, IStartGame, IEndGame
    {

        [SerializeField]
        private Text text;

        private void Awake()
        {
            this.text.text = "";
        }

        public void StartGame(GameConfig gameConfig)
        {
            this.text.text = gameConfig.Name;
        }

        public void EndGame()
        {
            this.text.text = "";
        }
        
    }
}