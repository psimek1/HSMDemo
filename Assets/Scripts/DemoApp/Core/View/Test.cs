using HSM;
using UnityEngine;

namespace DemoApp.Core.View
{
    public class Test : MonoBehaviour
    {

        private HSMManager hsmManager;

        void Start()
        {
            this.hsmManager = new HSMManager(new DemoAppState());
            this.hsmManager.Run();
        }
        
    }
}
