using DemoApp.Core.Data;
using DemoApp.ThingsOnShelfGame.States;

namespace DemoApp.ThingsOnShelfGame.Data
{
    public class ThingsOnShelfGameConfig: GameConfig<ThingsOnShelfGameTaskState>
    {

        public override string Name => "Věci na poličce";
        
    }
}