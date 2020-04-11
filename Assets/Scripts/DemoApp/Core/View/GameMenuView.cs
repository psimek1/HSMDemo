using DemoApp.Core.Data;
using HSM;
using UnityEngine;

namespace DemoApp.Core.View
{
    
    public class GameMenuView : HSMViewComponent, IEnterGame
    {
        
        [SerializeField]
        private GameObject startTaskPrefab;

        public void EnterGame(GameConfig gameConfig)
        {

            int count = gameConfig.Tasks.Count;

            for (int i = this.transform.childCount; i < count; i++)
            {
                Instantiate(this.startTaskPrefab, this.transform);
            }
            
        }
        
    }
    
}
