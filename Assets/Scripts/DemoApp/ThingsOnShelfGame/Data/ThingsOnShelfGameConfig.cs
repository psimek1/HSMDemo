using DemoApp.Core.Data;
using DemoApp.ThingsOnShelfGame.States;

namespace DemoApp.ThingsOnShelfGame.Data
{
    public class ThingsOnShelfGameConfig: GameConfig<ThingsOnShelfGameTaskState>
    {

        public ThingsOnShelfGameConfig()
        {
            this.Name = "Things on Shelf";
        }

    }
}