using System.Collections;
using DemoApp.Core.Actions;
using DemoApp.Core.Data;
using HSM;
using UnityEngine;
using UnityEngine.UI;

namespace DemoApp.Core.View
{
    public class MouseCharacterView : HSMViewComponent, IPlayMouseSpeech
    {

        [SerializeField]
        private Text text;
        
        public void PlayMouseSpeech(MouseSpeech speech)
        {
            StartCoroutine(PlayMouseSpeechCoroutine(speech));
        }

        private IEnumerator PlayMouseSpeechCoroutine(MouseSpeech speech)
        {
            this.text.text = "Myšák říká: " + speech.Text;
            
            yield return new WaitForSeconds(3);

            this.text.text = "";
            
            CreateAction<MouseSpeechFinishedAction>().WithSpeech(speech).Dispatch();
        }
        
    }
}
