using DemoApp.ThingsOnShelfGame;
using HSM;

namespace DemoApp.Core
{
    public class GameTaskState: HSMState
    {

        private ThingsOnShelfGameTaskState thingsOnShelfGameTaskState;
        
        public GameTaskState() : base()
        {
            this.name = "GameTask";
            
            AddChildState(new ThingsOnShelfGameTaskState());
        }
    }
}