using DemoApp.Core.Data;
using HSM;

namespace DemoApp.Core.Actions
{
    
    public abstract class MouseSpeechAction: HSMAction
    {
        public MouseSpeech Speech { get; private set; }

        public MouseSpeechAction WithSpeech(MouseSpeech value)
        {
            this.Speech = value;
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