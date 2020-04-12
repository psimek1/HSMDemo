using System.Collections.Generic;
using HSM;

namespace DemoApp.Core.Data
{

    public abstract class GameConfig
    {
        
        public abstract string Name { get; }

        public List<GameTaskConfig> Tasks { get; set; }
        
        public abstract HSMState CreateTaskState();

    }
    
    public abstract class GameConfig<TTaskState>: GameConfig where TTaskState: HSMState, new()
    {
        
        public override HSMState CreateTaskState()
        {
            return new TTaskState();
        }

    }
    
}