using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolisTest3
{
    internal class Person
    {
        public int MovementY { get; set; }
        public int MovementX { get; set; }
        public int PlacementY { get; set; }
        public int PlacementX { get; set; }        
        public string Name { get; set; }

    }


    internal class Robber : Person
    {
        public List<string> Loot { get; set; }
        public bool Thief { get; set; }
    }

    internal class Citizen : Person
    {
        public List<string> Belongings { get; set; }
    }


    internal class Police : Person
    {
        //Add more code and Constructors
    }
}
