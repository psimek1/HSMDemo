using System.Collections.Generic;
using HSM;

namespace DemoApp.Core.Data
{

    public abstract class GameConfig
    {
        
        public string Name { get; protected set; }

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