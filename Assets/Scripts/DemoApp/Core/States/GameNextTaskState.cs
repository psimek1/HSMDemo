 using DemoApp.Core.Actions;
 using DemoApp.Core.View;
 using HSM;
 
 namespace DemoApp.Core.States
 {
     public class GameNextTaskState: HSMState
     {
         
         public override string Name => "GameNextTask";
 
         public override void OnStateEnter()
         {
             base.OnStateEnter();
             
             ForEachViewComponent<IShowNextTaskMenu>(c => c.ShowNextTaskMenu());
         }

         public override void OnStateExit()
         {
             base.OnStateExit();
             
             ForEachViewComponent<IHideNextTaskMenu>(c => c.HideNextTaskMenu());
         }

         public override void HandleAction(HSMAction action)
         {
             base.HandleAction(action);
             
             if (action is BackAction)
             {
                 CreateAction<ExitTaskAction>().Dispatch();
                
                 action.SetHandled();
             }
         }
         
     }
     
 }