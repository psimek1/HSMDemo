using DemoApp.ThingsOnShelfGame.Data;
using HSM;

namespace DemoApp.ThingsOnShelfGame.View
{
    public interface IInitThingsOnShelfTask
    {
        void InitThingsOnShelfTask(ThingsOnShelfGameTaskConfig thingsOnShelfGameTaskConfig);
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
    
    public interface IFinishThingsOnShelfTask
    {
        void FinishThingsOnShelfTask();
    }
}