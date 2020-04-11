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
    
    public interface IEnterGame
    {
        void EnterGame(GameConfig gameConfig);
    }
    
    public interface IExitGame
    {
        void ExitGame();
    }

    public interface IShowGameMenu
    {
        void ShowGameMenu();
    }

    public interface IHideGameMenu
    {
        void HideGameMenu();
    }

    public interface IEnterTask
    {
        void EnterTask();
    }
    
    public interface IExitTask
    {
        void ExitTask();
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
    
    public interface IStopMouseSpeech
    {
        void StopMouseSpeech();
    }
    
}