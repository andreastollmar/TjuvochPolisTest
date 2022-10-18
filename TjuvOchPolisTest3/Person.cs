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
        public List<string> Inventory { get; set; }
        public string Name { get; set; }

    }


    internal class Robber : Person
    { 
        //Add more code
    }

    internal class Citizen : Person
    {
        //add more code
    }


    internal class Police : Person
    {
        //Add more code and Constructors
    }
}
