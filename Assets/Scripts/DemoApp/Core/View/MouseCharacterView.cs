using System.Collections;
using DemoApp.Core.Actions;
using DemoApp.Core.Data;
using HSM;
using UnityEngine;
using UnityEngine.UI;

namespace DemoApp.Core.View
{
    public class MouseCharacterView : HSMViewComponent, IPlayMouseSpeech, IStopMouseSpeech
    {

        [SerializeField]
        private Text text;
        
        public void PlayMouseSpeech(MouseSpeech speech)
        {
            StartCoroutine(PlayMouseSpeechCoroutine(speech));
        }

        public void StopMouseSpeech()
        {
            StopAllCoroutines();

            Say("");
        }
        
        private IEnumerator PlayMouseSpeechCoroutine(MouseSpeech speech)
        {
            Say("Myšák říká: " + speech.Text);
            
            yield return new WaitForSeconds(3);

            Say("");
            
            CreateAction<MouseSpeechFinishedAction>().WithSpeech(speech).Dispatch();
        }

        private void Say(string text)
        {
            this.text.text = text;
        }
       
    }
}
