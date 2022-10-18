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

        public Person()
        {
            Random rnd = new Random();            
            MovementY = rnd.Next(-1, 2);
            MovementX = rnd.Next(-1, 2);
            PlacementY = rnd.Next(0, 99);
            PlacementX = rnd.Next(0, 24);
        }

        public void Movement()
        {
            PlacementX = MovementCheckX();
            PlacementY = MovementCheckY();
        }        
        
        public int MovementCheckX()
        {
            int placementX = PlacementX += MovementX;
            if (placementX < 0)
            {
                placementX = 24;
            }
            else if (placementX > 24)
            {
                placementX = 0;
            }
            return placementX;
        }
        public int MovementCheckY()
        {
            int placementY = PlacementY += MovementY;
            if (placementY < 0)
            {
                placementY = 99;
            }
            else if (placementY > 99)
            {
                placementY = 0;
            }
            return placementY;
        }
    }


    internal class Robber : Person
    {
        public List<string> Loot { get; set; }
        public bool Thief { get; set; }

        //public bool InPrison { get; set; }

        //public DateTime TimeOfCapture { get; set; }

        //public double TimeInPreison { get; set; }
        public Robber(bool inPresion , DateTime timeOfCapture, double timeInPersion) : base()
        {
            Name = "R";
            Thief = false;
            //InPrison = inPresion;
            //TimeOfCapture = timeOfCapture;
            //TimeInPreison = timeInPersion;
            Loot = new List<string>();
        }
    }

    internal class Citizen : Person
    {
        public List<string> Belongings { get; set; }

        public Citizen(): base()
        {
            Stuff stuff = new Stuff();
            Name = "C";
            Belongings = new List<string>();
            Belongings.AddRange(stuff.stuff);

        }
    }
    


    internal class Police : Person
    {
        public List<string> StolenGoods { get; set; }

        public Police(): base()
        {
            Name = "P";
            StolenGoods = new List<string>();
        }
    }
}
