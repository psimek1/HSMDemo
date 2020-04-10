using System;
using UnityEngine;

namespace HSM
{

    public abstract class HSMViewRoot : MonoBehaviour
    {
        protected HSMManager hsmManager;

        public HSMManager HSMManager => hsmManager;
        
        public void ForEachViewComponent<T>(Action<T> action) where T: class
        {
            var viewComponents = GetComponentsInChildren<HSMViewComponent>(true);
            foreach (var component in viewComponents)
            {
                if (component is T)
                {
                    action.Invoke(component as T);
                }
            }
        }
    }
    
    public abstract class HSMViewRoot<TRootState>: HSMViewRoot where TRootState: HSMState, new()
    {
        private void Awake()
        {
            this.hsmManager = new HSMManager<TRootState>(this);
        }

        private void Start()
        {
            this.hsmManager.Run();
        }
    }
    
}