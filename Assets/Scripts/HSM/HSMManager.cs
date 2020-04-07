using System;
using System.Collections.Generic;
using UnityEngine;

namespace HSM
{
    public class HSMManager
    {

        private readonly HSMState rootState;
        
        private HSMState currentState;

        private readonly Queue<HSMAction> actionQueue;

        private bool isStateTransition;

        private HSMViewRoot viewRoot;

        public HSMManager(HSMState rootState, HSMViewRoot viewRoot)
        {
            this.rootState = rootState;
            this.rootState.Manager = this;

            this.viewRoot = viewRoot;
            
            this.actionQueue = new Queue<HSMAction>();
        }

        public void Run()
        {
            SwitchState(this.rootState);
        }

        public void SwitchState(HSMState state)
        {
            if (state != this.currentState)
            {
                this.isStateTransition = true;
                var s = this.currentState;
                while (s != null && !state.IsChildOf(s))
                {
                    s.OnStateExit();
                    s = s.ParentState;
                }
                this.currentState = state;
                state.OnStateEnter();
                this.isStateTransition = false;
                ProcessActionQueue();
            }
        }

        public TAction CreateAction<TAction>() where TAction : HSMAction, new()
        {
            // todo doimplementovat object pooling
            return new TAction {HSMManager = this};
        }
        
        internal void DispatchAction(HSMAction action)
        {
            this.actionQueue.Enqueue(action);
            ProcessActionQueue();
        }

        public T GetModel<T>() where T : class
        {
            return this.currentState?.GetModel<T>();
        }
        
        public void ForEachViewComponent<T>(Action<T> action) where T: class
        {
            this.viewRoot.ForEachViewComponent(action);
        }

        private void ProcessActionQueue()
        {
            while (!this.isStateTransition && this.actionQueue.Count > 0)
            {
                var action = this.actionQueue.Dequeue();
                var state = this.currentState;
                while (!action.Handled && state != null)
                {
                    state.HandleAction(action);
                    state = state.ParentState;
                }
            }
        }
        
    }
}