using DemoApp.Core.Data;

namespace DemoApp.Core.View
{
    public interface IInitGame
    {
        void InitGame(Game game);
    }
    
    public interface IPlayMouseSpeech
    {
        void PlayMouseSpeech(MouseSpeech speech);
    }
    
}