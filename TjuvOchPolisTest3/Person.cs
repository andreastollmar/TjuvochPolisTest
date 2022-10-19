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
            Name = "";
        }

        public void Movement()
        {
            PlacementX = MovementCheckX();
            PlacementY = MovementCheckY();
        }        
        
        public virtual int MovementCheckX()
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
        public virtual int MovementCheckY()
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

        public bool InPrison { get; set; }

        public DateTime TimeOfCapture { get; set; }

        public double TimeInPrison { get; set; }

        public override int MovementCheckX()
        {
            int placementX = PlacementX;
            if (InPrison)
            {
                placementX = PlacementX += MovementX;
                if (placementX < 1)
                {
                    placementX = 10;
                }
                else if (placementX > 10)
                {
                    placementX = 1;
                }
                return placementX;
            }
            else
            {
                placementX = PlacementX += MovementX;
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
            
        }
        public override int MovementCheckY()
        {
            int placementY = PlacementY; 
            if(InPrison)
            {
                placementY = PlacementY += MovementY;
                if (placementY < 1)
                {
                    placementY = 10;
                }
                else if (placementY > 10)
                {
                    placementY = 1;
                }
            return placementY;
            }
            else
            {
                placementY = PlacementY += MovementY;
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

        public Robber()
        {
            Name = "R";
            Thief = false;
            Loot = new List<string>();
            InPrison = false;
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
