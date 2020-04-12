using DemoApp.Core.Data;

namespace DemoApp.Core.View
{

    public interface IEnterApp
    {
        void EnterApp();
    }
    
    public interface IEnterMenu
    {
        void EnterMenu();
    }
    
    public interface IExitMenu
    {
        void ExitMenu();
    }
    
    public interface IEnterGame
    {
        void EnterGame();
    }
    
    public interface IExitGame
    {
        void ExitGame();
    }

    public interface IEnterGameMenu
    {
        void EnterGameMenu();
    }

    public interface IExitGameMenu
    {
        void ExitGameMenu();
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