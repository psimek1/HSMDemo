using HSM;

namespace DemoApp.ThingsOnShelfGame.View
{
    public class ThingsView : HSMViewComponent, IInitTask
    {
        public void InitTask(ThingsSet thingsSet)
        {
            // todo
            
            CreateAction<TaskViewReadyAction>().Dispatch();
        }
    }
}
