using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.Data
{
    public class FixtureArgs : IEnumerable
    {
       // private static List<string[]> Args = null;

        //public FixtureArgs()
        //{
        //    FixtureArgs = new List<string[]>(AppConfig.BrowsersEnabled.Select(x => new string[] { x.Browser, x.Version, x.Platform }));
        //}

        public IEnumerator GetEnumerator()
        {
            yield return "CH";
            yield return "FF";
        }
    }
}
