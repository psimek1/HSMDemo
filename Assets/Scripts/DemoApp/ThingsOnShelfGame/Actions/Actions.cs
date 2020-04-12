using HSM;

namespace DemoApp.ThingsOnShelfGame.Actions
{

    public class TaskViewReadyAction : HSMAction
    {
        
    }
    
    public class TaskReadyAction: HSMAction
    {
        
    }
    
    public class ThingSelectedAction: HSMAction
    {

        private int index;

        public int Index => index;

        public ThingSelectedAction WithIndex(int value)
        {
            this.index = value;
            return this;
        }
        
    }

    public class TaskResultFinishedAction : HSMAction
    {
        
    }
    
    public class TaskViewFinishedAction : HSMAction
    {
        
    }
    
}