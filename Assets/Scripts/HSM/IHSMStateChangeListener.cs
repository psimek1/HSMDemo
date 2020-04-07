namespace HSM
{
    public interface IHSMStateChangeListener
    {

        void OnStateChange(HSMState oldState, HSMState newState);
        
    }
}