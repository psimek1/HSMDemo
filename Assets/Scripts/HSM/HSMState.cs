using System;
using System.Collections.Generic;

namespace HSM
{
    public abstract class HSMState: HSMStateModuleBase
    {
        private HSMState parentState;

        private readonly List<HSMState> childStates;

        private readonly List<HSMStateModule> modules;

        protected HSMState()
        {
            this.childStates = new List<HSMState>();
            this.modules = new List<HSMStateModule>();
        }

        public HSMState ParentState
        {
            get => this.parentState;
            private set => this.parentState = value;
        }
        public override string FullName => this.parentState != null ? this.parentState.FullName + "." + this.Name : this.Name;

        internal override void Init(HSMManager hsmManager)
        {
            base.Init(hsmManager);
            
            AddChildStates();
            AddModules();
        }

        protected virtual void AddChildStates()
        {
            
        }

        protected virtual void AddModules()
        {
            
        }
        
        protected void AddChildState(HSMState state)
        {
            if (!this.childStates.Contains(state))
            {
                this.childStates.Add(state);
                state.ParentState = this;
                state.Init(this.manager);
            }
        }

        protected void AddModule(HSMStateModule module)
        {
            if (!this.modules.Contains(module))
            {
                this.modules.Add(module);
                module.OwnerState = this;
                module.Init(this.manager);
            }
        }

        public void SwitchState(HSMState state)
        {
            if (!state.IsChildOf(this))
            {
                throw new Exception("Cannot switch to non-child state.");
            }
            this.Manager.SwitchState(state);
        }

        public bool IsChildOf(HSMState state)
        {
            if (this == state)
            {
                return true;
            }

            if (this.parentState == null)
            {
                return false;
            }

            return this.parentState.IsChildOf(state);
        }
    
        public override T GetModel<T>()
        {
            T model = null;
            if (this is T)
            {
                model = this as T;
            }
            if (model == null)
            {
                model = this.modules.Find(module => module is T) as T;
            }
            if (model == null)
            {
                return parentState?.GetModel<T>();
            }

            return model;
        }

        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);
            
            this.modules.ForEach(module => module.HandleAction(action));
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            this.modules.ForEach(module => module.OnStateEnter());
        }
        
        public override void OnStateExit()
        {
            base.OnStateExit();
            
            this.modules.ForEach(module => module.OnStateExit());
        }
        
    }
    
}
