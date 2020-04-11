using HSM;

namespace DemoApp.Core.Actions
{

    public class TaskSelectedAction : HSMAction
    {
        
        public int Index { get; private set; }

        public TaskSelectedAction WithIndex(int value)
        {
            this.Index = value;
            return this;
        }
        
    }
    
    public class TaskFinishedAction: HSMAction
    {
        
        public bool Success { get; private set; }

        public TaskFinishedAction WithSuccess()
        {
            this.Success = true;
            return this;
        }
        
        public TaskFinishedAction WithFail()
        {
            this.Success = false;
            return this;
        }
        
    }

    public class NextTaskRequestAction : HSMAction
    {
        
    }
    
    
}