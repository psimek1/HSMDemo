using HSM;

namespace DemoApp.Core.Actions
{
    
    public abstract class MouseSpeechAction: HSMAction
    {

        private string speechId;

        public string SpeechId => speechId;

        public MouseSpeechAction WithSpeechId(string value)
        {
            this.speechId = value;
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