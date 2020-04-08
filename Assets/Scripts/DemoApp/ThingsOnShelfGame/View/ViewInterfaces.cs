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

    
}