namespace HSM
{
    public class HSMAction
    {

        private HSMManager hsmManager;

        internal HSMManager HSMManager
        {
            set => hsmManager = value;
        }

        private bool handled;

        public bool Handled
        {
            get => this.handled;
            set => this.handled = value;
        }

        public void Dispatch()
        {
            this.hsmManager.DispatchAction(this);
        }
        
    }
}