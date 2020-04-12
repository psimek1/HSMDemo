using DemoApp.Core.Actions;
using DemoApp.Core.States;
using DemoApp.ThingsOnShelfGame.Actions;
using DemoApp.ThingsOnShelfGame.Data;
using HSM;

namespace DemoApp.ThingsOnShelfGame.States
{

    public interface IThingsOnShelfGameTask
    {
        
        ThingsOnShelfGameTaskConfig CurrentGameTask { get; }
        
        bool IsSuccess { get; }
        
    }
    
    public class ThingsOnShelfGameTaskState: HSMState, IThingsOnShelfGameTask
    {

        public override string Name => "ThingsOnShelfGameTask";

        public ThingsOnShelfGameTaskConfig CurrentGameTask => GetModel<IGame>().CurrentGameTask as ThingsOnShelfGameTaskConfig;
        
        public bool IsSuccess { get; private set; }

        private InitState initState;
        private InputState inputState;
        private ResultState resultState;
        private FinishState finishState;

        protected override void AddChildStates()
        {
            AddChildState(this.initState = new InitState());
            AddChildState(this.inputState = new InputState());
            AddChildState(this.resultState = new ResultState());
            AddChildState(this.finishState = new FinishState());
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            this.IsSuccess = false;

            SwitchState(this.initState);
        }

        public override void HandleAction(HSMAction action)
        {
            base.HandleAction(action);

            if (action is TaskReadyAction)
            {
                SwitchState(this.inputState);
                action.SetHandled();
            }
            
            else if (action is ThingSelectedAction thingSelectedAction)
            {
                this.IsSuccess = thingSelectedAction.Index == this.CurrentGameTask.CorrectThingIndex;
                SwitchState(this.resultState);
                action.SetHandled();
            }
            
            else if (action is TaskResultFinishedAction)
            {
                SwitchState(this.finishState);
                action.SetHandled();
            }

            else if (action is TaskViewFinishedAction)
            {
                CreateAction<TaskFinishedAction>().WithSuccess(this.IsSuccess).Dispatch();
                action.SetHandled();
            }
            
        }
        
    }
    
}