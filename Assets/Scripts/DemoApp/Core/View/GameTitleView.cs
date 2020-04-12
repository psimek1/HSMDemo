using DemoApp.Core.States;
using HSM;
using UnityEngine;
using UnityEngine.UI;

namespace DemoApp.Core.View
{
    public class GameTitleView : HSMViewComponent, IEnterGame, IExitGame
    {

        [SerializeField]
        private Text text;

        private void Awake()
        {
            this.text.text = "";
        }

        public void EnterGame()
        {
            this.text.text = GetModel<IApp>().CurrentGame.Name;
        }

        public void ExitGame()
        {
            this.text.text = "";
        }
        
    }
}