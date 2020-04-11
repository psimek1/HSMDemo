using Utils;

namespace HSM
{
    public class HSMViewComponent: ViewComponent
    {

        private HSMViewRoot hsmViewRoot;

        private HSMViewRoot GetHSMViewRoot()
        {
            if (this.hsmViewRoot == null)
            {
                this.hsmViewRoot = GetComponentInParent<HSMViewRoot>();
            }

            return this.hsmViewRoot;
        }

        protected TAction CreateAction<TAction>() where TAction: HSMAction, new()
        {
            return GetHSMViewRoot()?.HSMManager?.CreateAction<TAction>();
        }

        protected TModel GetModel<TModel>() where TModel: class
        {
            return GetHSMViewRoot()?.HSMManager?.GetModel<TModel>();
        }

    }
}