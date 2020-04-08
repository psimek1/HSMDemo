using DemoApp.Core.Data;
using HSM;

namespace DemoApp.Core.Actions
{
    
    public abstract class MouseSpeechAction: HSMAction
    {

        private MouseSpeech speech;

        public MouseSpeech Speech => speech;

        public MouseSpeechAction WithSpeech(MouseSpeech value)
        {
            this.speech = value;
            return this;
        }
        
    }
    
    public class PlayMouseSpeechAction: MouseSpeechAction
    {
        
    }
    
    public class MouseSpeechFinishedAction: MouseSpeechAction
    {
        
    }
    
}