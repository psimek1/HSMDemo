using DemoApp.Core.Data;

namespace DemoApp.Core.View
{

    public interface IShowMenu
    {
        void ShowMenu();
    }
    
    public interface IHideMenu
    {
        void HideMenu();
    }
    
    public interface IStartGame
    {
        void StartGame(GameConfig gameConfig);
    }
    
    public interface IEndGame
    {
        void EndGame();
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