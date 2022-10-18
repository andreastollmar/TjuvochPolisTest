using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolisTest3
{
    internal class City
    {
        public static string[,] city = new string[25, 100];
        public static List<Robber> robbers = new List<Robber>();
        public static List<Citizen> citizens = new List<Citizen>();
        public static List<Police> polices = new List<Police>();


        public void Start()
        {
            List();

            while (true)
            {
                foreach (Citizen citizen in citizens)
                {
                    city[citizen.PlacementX, citizen.PlacementY] = citizen.Name;
                    citizen.Movement();
                }

                foreach (Robber robber in robbers)
                {
                    if (city[robber.PlacementX, robber.PlacementY] == "C")
                    {
                        //Metod för att stjäla items
                        Console.WriteLine("Här står en tjuv/citisen");
                    }
                    else
                    {
                        city[robber.PlacementX, robber.PlacementY] = robber.Name;
                    }                    
                    robber.Movement();
                }

                foreach (Police police in polices)
                {
                    city[police.PlacementX, police.PlacementY] = police.Name;
                    police.Movement();
                }

                for (int i = 0; i < city.GetLength(0); i++)
                {
                    for (int j = 0; j < city.GetLength(1); j++)
                    {
                        if (city[i, j] != null)
                        {
                            Console.Write(city[i, j]);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
                Console.Clear();
                for (int i = 0; i < city.GetLength(0); i++)
                {
                    for (int j = 0; j < city.GetLength(1); j++)
                    {
                        city[i,j] = null;                                              
                    }                   
                }


            }
            
        }

        public static void List()
        {
            for (int i = 0; i < 10; i++)
            {
                Police police = new Police();
                polices.Add(police);
            }
            for(int i = 0; i < 30; i++)
            {
                Citizen citizen = new Citizen();
                citizens.Add(citizen);
            }
            for (int i = 0; i < 20; i++)
            {
                Robber robber = new Robber();
                robbers.Add(robber);
            }
        }
    }
}
