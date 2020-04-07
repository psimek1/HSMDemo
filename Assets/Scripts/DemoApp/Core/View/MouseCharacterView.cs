using System.Collections;
using DemoApp.Core.Actions;
using HSM;
using UnityEngine;
using UnityEngine.UI;

namespace DemoApp.Core.View
{
    public class MouseCharacterView : HSMViewComponent, IPlayMouseSpeech
    {

        [SerializeField]
        private Text text;
        
        public void PlayMouseSpeech(string speechId)
        {
            StartCoroutine(PlayMouseSpeechCoroutine(speechId));
        }

        private IEnumerator PlayMouseSpeechCoroutine(string speechId)
        {
            this.text.text = "Myšák říká: " + speechId;
            
            yield return new WaitForSeconds(3);

            this.text.text = "";
            
            CreateAction<MouseSpeechFinishedAction>().WithSpeechId(speechId).Dispatch();
        }
        
    }
}
