using HSM;
using UnityEngine;
using UnityEngine.UI;

namespace DemoApp.ThingsOnShelfGame.View
{
    public class ThingView : HSMViewComponent, IInitTask
    {

        [SerializeField]
        private int index;

        [SerializeField]
        private Color32[] colors;
        
        public void InitTask(ThingsSet thingsSet)
        {
            GetComponent<Image>().color = this.colors[thingsSet.Values[this.index]];
        }
    }
}
