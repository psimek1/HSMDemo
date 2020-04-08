using System;
using System.Collections.Generic;

namespace HSM
{
    public class AsyncCallQueue
    {

        private Queue<Action<Action>> queue;

        private Action exitCallback;

        public AsyncCallQueue()
        {
            this.queue = new Queue<Action<Action>>();
        }

        public void Clear()
        {
            this.queue.Clear();
        }

        public void Enqueue(Action<Action> call)
        {
            this.queue.Enqueue(call);
        }

        public void RunQueue(Action callback)
        {
            this.exitCallback = callback;
            ProcessQueue();
        }

        private void ProcessQueue()
        {
            if (this.queue.Count > 0)
            {
                var call = this.queue.Dequeue();
                call.Invoke(ProcessQueue);
            }
            else
            {
                exitCallback?.Invoke();
                exitCallback = null;
            }
        }
        
    }
}