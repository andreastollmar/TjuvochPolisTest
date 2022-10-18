using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolisTest3
{
    internal class Stuff
    {
        public string[] stuff = { "Money", "Keys", "Cellphone", "Watch" };
        static int robbed = 0;
        static int arrested = 0;



        public void StealItem(List<string> belongnings, List<string>stolen)
        {
            Random rnd = new Random();
            int steal = rnd.Next(0, (belongnings.Count));
            string taken = belongnings[steal];
            stolen.Add(taken);
            belongnings.RemoveAt(steal);
            robbed++;            
        }
        public void TakeAllItems(List<string> stolen, List<string> retaken)
        {
            retaken.AddRange(stolen);
            stolen.Clear();
            arrested++;
        }

    }
}
