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
        Stuff stuff = new Stuff();
        Person person = new Person();
        public static List<Person> persons = new List<Person>();


        public void Start()
        {
            List();

            while (true)
            {
                foreach (Person persons in persons)
                {
                    persons.Movement();
                    //city[persons.PlacementX, persons.PlacementY] = persons.Name;





                    if (persons is Citizen)
                    {
                        city[persons.PlacementX, persons.PlacementY] = persons.Name;
                    }
                    if (persons is Robber)
                    {
                        if (city[(((Robber)persons).PlacementX), (((Robber)persons).PlacementY)] == "C")
                        {
                            foreach (Citizen citizen in citizens)
                            {
                                if (citizen.PlacementX == (((Robber)persons).PlacementX) && citizen.PlacementY == (((Robber)persons).PlacementY))
                                {
                                    stuff.StealItem(citizen.Belongings, (((Robber)persons).Loot));
                                    (((Robber)persons).Thief) = true;  
                                }
                            }

                            city[(((Robber)persons).PlacementX), (((Robber)persons).PlacementY)] = "[y]";


                            Console.WriteLine("Medborgare blev rånad");
                        }
                        else
                        {
                            city[persons.PlacementX, persons.PlacementY] = persons.Name;
                        }
                    }
                    if (persons is Police)
                    {
                        if (city[(((Police)persons).PlacementX), (((Police)persons).PlacementY)] == "R")
                        {
                            foreach (Robber robber in robbers)
                            {
                                if (robber.PlacementX == (((Police)persons).PlacementX) && robber.PlacementY == (((Police)persons).PlacementY))
                                {
                                    stuff.TakeAllItems(robber.Loot, (((Police)persons).StolenGoods));
                                }
                            }                
                            
                            city[(((Police)persons).PlacementX), (((Police)persons).PlacementY)] = "[x]";


                            Console.WriteLine("Tjuv blev arresterad");                            
                        }
                        else
                        {
                            city[persons.PlacementX, persons.PlacementY] = persons.Name;
                        }
                    }


                }

                //foreach (Robber robber in robbers)
                //{
                //    if (city[robber.PlacementX, robber.PlacementY] == "C")
                //    {
                //        stuff.StealItem()
                //    }
                //    else
                //    {
                //        city[robber.PlacementX, robber.PlacementY] = robber.Name;
                //    }                    
                //    robber.Movement();
                //}

                //foreach (Police police in polices)
                //{
                //    city[police.PlacementX, police.PlacementY] = police.Name;
                //    police.Movement();
                //}

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
                //Console.WriteLine("Police: ");
                //foreach (Police polis in polices)
                //{

                //    if (polis.StolenGoods.Count > 0)
                //    {
                //        for (int i = 0; i < polis.StolenGoods.Count; i++)
                //        {
                //            Console.WriteLine(polis.StolenGoods[i]);
                //        }
                //    }
                //}
                //Console.WriteLine("Robbers: ");
                //foreach (Robber robber in robbers)
                //{

                //    if (robber.Loot.Count > 0)
                //    {
                //        for (int i = 0; i < robber.Loot.Count; i++)
                //        {
                //            Console.WriteLine(robber.Loot[i]);
                //        }
                //    }
                //}
                //Console.WriteLine("Citizens: ");
                //foreach (Citizen citizen in citizens)
                //{

                //    if (citizen.Belongings.Count > 0)
                //    {
                //        for (int i = 0; i < citizen.Belongings.Count; i++)
                //        {
                //            Console.WriteLine(citizen.Belongings[i]);
                //        }
                //    }
                //}
                Console.ReadKey();
                Console.Clear();
                for (int i = 0; i < city.GetLength(0); i++)
                {
                    for (int j = 0; j < city.GetLength(1); j++)
                    {
                        city[i,j] = " ";                                              
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
            persons.AddRange(citizens);
            persons.AddRange(robbers);
            persons.AddRange(polices);
        }
    }
}
