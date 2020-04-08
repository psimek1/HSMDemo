namespace HSM
{
    public class HSMAction
    {

        private HSMManager hsmManager;

        internal HSMManager HSMManager
        {
            set => hsmManager = value;
        }

        public bool Handled { get; private set; }

        public void Dispatch()
        {
            this.hsmManager.DispatchAction(this);
        }

        public void SetHandled()
        {
            this.Handled = true;
        }
        
    }
}