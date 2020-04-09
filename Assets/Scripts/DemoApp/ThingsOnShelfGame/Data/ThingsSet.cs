using System.Collections.Generic;

namespace DemoApp.ThingsOnShelfGame.Data
{
    public class ThingsSet
    {

        public List<int> Values { get; set; }

        public int CorrectThingIndex
        {
            get { return this.Values.FindIndex(i => i==1); }
        }

    }
}