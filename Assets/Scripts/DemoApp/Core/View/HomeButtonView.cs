﻿using DemoApp.Core.Actions;
using HSM;
using UnityEngine.EventSystems;

namespace DemoApp.Core.View
{
    public class HomeButtonView : HSMViewComponent, IEnterMenu, IExitMenu, IPointerClickHandler
    {
        public void Awake()
        {
            Deactivate();
        }

        public void EnterMenu()
        {
            Deactivate();
        }

        public void ExitMenu()
        {
            Activate();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            CreateAction<HomeAction>().Dispatch();
        }
        
    }
}
