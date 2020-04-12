using DemoApp.Core.Data;
using DemoApp.Core.States;
using HSM;
using UnityEngine;

namespace DemoApp.Core.View
{
    
    public class GameMenuView : HSMViewComponent, IEnterGame
    {
        
        [SerializeField]
        private GameObject startTaskPrefab;

        public void EnterGame()
        {

            int count = GetModel<IApp>().CurrentGame.Tasks.Count;

            for (int i = this.transform.childCount; i < count; i++)
            {
                Instantiate(this.startTaskPrefab, this.transform);
            }
            
        }
        
    }
    
}
