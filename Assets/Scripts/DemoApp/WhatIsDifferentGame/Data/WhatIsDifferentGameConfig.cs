using DemoApp.Core.Data;
using DemoApp.WhatIsDifferentGame.States;

namespace DemoApp.WhatIsDifferentGame.Data
{
    public class WhatIsDifferentGameConfig : GameConfig<WhatIsDifferentGameTaskState>
    {
        
        public override string Name => "Co je jinak?";

    }
}
