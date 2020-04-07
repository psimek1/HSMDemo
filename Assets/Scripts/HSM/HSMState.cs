using System;
using System.Collections.Generic;
using UnityEngine;

namespace HSM
{
    public abstract class HSMState
    {

        private HSMManager manager;

        internal HSMManager Manager
        {
            get => this.manager;
            set
            {
                this.manager = value;
                foreach (var childState in childStates)
                {
                    childState.manager = value;
                }
            }
        }

        protected string name;

        private HSMState parentState;

        private readonly List<HSMState> childStates;

        protected HSMState()
        {
            this.childStates = new List<HSMState>();
        }

        public HSMState ParentState
        {
            get => this.parentState;
            private set => this.parentState = value;
        }

        public string Name => this.name;
        public string FullName => this.parentState != null ? this.parentState.FullName + "." + this.name : this.name;

        protected void AddChildState(HSMState state)
        {
            if (!this.childStates.Contains(state))
            {
                this.childStates.Add(state);
                state.ParentState = this;
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
    
        public T GetModel<T>() where T: class
        {
            if (this is T)
            {
                return this as T;
            }
            else
            {
                return parentState?.GetModel<T>();
            }
        }

        public TAction CreateAction<TAction>() where TAction : HSMAction, new()
        {
            return this.manager.CreateAction<TAction>();
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
    
}
