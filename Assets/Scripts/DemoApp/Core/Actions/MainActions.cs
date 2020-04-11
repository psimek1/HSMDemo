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
    
    public class BackAction : HSMAction
    {
        
    }

    public class HomeAction : HSMAction
    {
        
    }
        
}