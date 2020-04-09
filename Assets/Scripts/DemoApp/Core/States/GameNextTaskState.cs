 using DemoApp.Core.View;
 using HSM;
 
 namespace DemoApp.Core.States
 {
     public class GameNextTaskState: HSMState
     {
         
         public override void OnStateInit()
         {
             base.OnStateInit();
             this.name = "gameNextTask";
         }
 
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
         
     }
     
 }