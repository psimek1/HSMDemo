using DemoApp.Core.Actions;
using DemoApp.Core.View;
using HSM;

namespace DemoApp.Core.States
{
    public class MouseSpeechStateModule: HSMStateModule
    {
        public override string Name => "MouseSpeech";

        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);

            if (action is PlayMouseSpeechAction playMouseSpeechAction)
            {
                ForEachViewComponent<IPlayMouseSpeech>(c => c.PlayMouseSpeech(playMouseSpeechAction.Speech));
            }
        }
        
    }
}