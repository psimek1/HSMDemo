using System;
using UnityEngine;

namespace HSM
{
    public abstract class HSMStateModuleBase
    {
        
        protected HSMManager manager;
        
        protected string name;
        
        public string Name => this.name;

        public abstract string FullName { get; }
        
        internal virtual HSMManager Manager
        {
            get => this.manager;
        }

        public abstract T GetModel<T>() where T : class;

        protected TAction CreateAction<TAction>() where TAction : HSMAction, new()
        {
            return this.manager.CreateAction<TAction>();
        }
        
        public void ForEachViewComponent<T>(Action<T> action) where T: class
        {
            this.manager.ForEachViewComponent(action);
        }

        internal void Init(HSMManager hsmManager)
        {
            this.manager = hsmManager;
                        
            this.OnStateInit();
        }
        
        public virtual void OnStateInit()
        {
        }
        
        public virtual void OnStateEnter()
        {
            Log("OnStateEnter");
        }

        public virtual void OnStateExit()
        {
            Log("OnStateExit");
        }
        
        public virtual void HandleAction(HSMAction action)
        {
            Log("HandleAction " + action);
        }
        
        public void Log(string msg)
        {
            Debug.Log(this.FullName + ": " + msg);
        }
        
    }

    public abstract class HSMStateModule: HSMStateModuleBase
    {

        public override string FullName => this.OwnerState?.FullName + "/" + this.name;
        
        internal HSMState OwnerState;
        
        public override T GetModel<T>()
        {
            return this.OwnerState.GetModel<T>();
        }

    }
}