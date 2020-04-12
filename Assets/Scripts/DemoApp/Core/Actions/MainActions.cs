using HSM;

namespace DemoApp.Core.Actions
{
    public class GameSelectedAction : HSMAction
    {
        
        public int Index { get; private set; }

        public GameSelectedAction WithIndex(int value)
        {
            this.Index = value;
            return this;
        }
        
    }

    public class ExitGameAction : HSMAction
    {
        
    }
    
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

        public TaskFinishedAction WithSuccess(bool value)
        {
            this.Success = value;
            return this;
        }
        
    }

    public class NextTaskRequestAction : HSMAction
    {
        
    }

    public class ExitTaskAction : HSMAction
    {
        
    }
    
    public class BackAction : HSMAction
    {
        
    }

    public class HomeAction : HSMAction
    {
        
    }
        
}