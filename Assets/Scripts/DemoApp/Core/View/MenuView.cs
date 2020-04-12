using DemoApp.Core.States;
using HSM;
using UnityEngine;

namespace DemoApp.Core.View
{
    public class MenuView: HSMViewComponent, IEnterApp, IEnterMenu, IExitMenu
    {

        [SerializeField]
        private GameObject menuItemPrefab;
        
        public void Awake()
        {
            Deactivate();
        }

        public void EnterApp()
        {
            int count = GetModel<IApp>().Games.Count;

            for (int i = 0; i < count; i++)
            {
                Instantiate(this.menuItemPrefab, this.transform);
            }
        }
        
        public void EnterMenu()
        {
            Activate();
        }

        public void ExitMenu()
        {
            Deactivate();
        }

    }
}
