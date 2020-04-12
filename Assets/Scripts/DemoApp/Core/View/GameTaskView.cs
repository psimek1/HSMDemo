using System.Collections.Generic;
using DemoApp.Core.Data;
using DemoApp.Core.States;
using HSM;
using UnityEngine;

namespace DemoApp.Core.View
{
    public class GameTaskView : HSMViewComponent, IEnterApp, IEnterGame, IEnterTask, IExitTask
    {

        [SerializeField]
        private GameObject[] gameTaskPrefabs;

        private Dictionary<GameConfig, GameObject> gameTaskGOsByGameConfig;
        
        public void Awake()
        {
            Deactivate();
        }

        public void EnterApp()
        {
            // Tady samozřejmě bude nějaké inteligentnější propojení mezi loadovanými herními moduly a configem.
            // Zde předpokládáme, že prefaby v poli gameTaskPrefabs odpovídají (počtem a pořadím) hrám v configu.
            
            var games = GetModel<IApp>().Games;

            this.gameTaskGOsByGameConfig = new Dictionary<GameConfig, GameObject>();
            
            for (int i = 0; i < games.Count; i++)
            {
                this.gameTaskGOsByGameConfig[games[i]] = Instantiate(this.gameTaskPrefabs[i], this.transform);
            }
        }
        
        public void EnterGame()
        {
            var currentGame = GetModel<IApp>().CurrentGame;
            
            foreach (var kvp in this.gameTaskGOsByGameConfig)
            {
                kvp.Value.SetActive(kvp.Key == currentGame);
            }
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
