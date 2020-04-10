using DemoApp.Core.Data;

namespace DemoApp.Core.View
{
    
    public interface IInitGame
    {
        void InitGame(GameConfig gameConfig);
    }

    public interface IStartTask
    {
        void StartTask();
    }
    
    public interface IEndTask
    {
        void EndTask();
    }
    
    public interface IShowNextTaskMenu
    {
        void ShowNextTaskMenu();
    }

    public interface IHideNextTaskMenu
    {
        void HideNextTaskMenu();
    }
    
    public interface IPlayMouseSpeech
    {
        void PlayMouseSpeech(MouseSpeech speech);
    }
    
}