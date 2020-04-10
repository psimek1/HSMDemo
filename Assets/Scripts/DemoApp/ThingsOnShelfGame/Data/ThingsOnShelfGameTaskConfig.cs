using System.Collections.Generic;
using DemoApp.Core.Data;

namespace DemoApp.ThingsOnShelfGame.Data
{
    public class ThingsOnShelfGameTaskConfig: GameTaskConfig
    {

        public List<int> Values { get; set; }

        public int CorrectThingIndex
        {
            get { return this.Values.FindIndex(i => i==1); }
        }

    }
}