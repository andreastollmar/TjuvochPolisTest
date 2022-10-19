using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolisTest3
{
    internal class Prison
    {
        public List<Person> prisoners = new List<Person>();

        public void ListPrisoners()
        {
            Console.WriteLine(prisoners.Count);
        }

    }
}
