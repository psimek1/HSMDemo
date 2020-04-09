using DemoApp.ThingsOnShelfGame.Data;
using HSM;

namespace DemoApp.ThingsOnShelfGame.View
{
    public interface IInitTask
    {
        void InitTask(ThingsSet thingsSet);
    }

    public interface IEnableInput
    {
        void EnableInput();
    }
    
    public interface IDisableInput
    {
        void DisableInput();
    }

    public interface IShowSolution
    {
        void ShowSolution(int correctThingIndex);
    }
    
    public interface IFinishTask
    {
        void FinishTask();
    }
}