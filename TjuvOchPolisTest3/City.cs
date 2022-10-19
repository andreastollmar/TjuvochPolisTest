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
        Prison prison = new Prison();
        public static List<Person> persons = new List<Person>();


        public void Start()
        {
            List();

            while (true)
            {
                foreach (Person people in persons)
                {
                    people.Movement();

                    if (people is Citizen)
                    {
                        city[people.PlacementX, people.PlacementY] = people.Name;
                    }
                    if (people is Robber)
                    {
                        if (city[(((Robber)people).PlacementX), (((Robber)people).PlacementY)] == "C")
                        {
                            foreach (Citizen citizen in citizens)
                            {
                                if (citizen.PlacementX == (((Robber)people).PlacementX) && citizen.PlacementY == (((Robber)people).PlacementY))
                                {
                                    stuff.StealItem(citizen.Belongings, (((Robber)people).Loot));
                                    (((Robber)people).Thief) = true;  
                                }
                            }

                            city[(((Robber)people).PlacementX), (((Robber)people).PlacementY)] = "[y]";


                            Console.WriteLine("Citizen was robbed!");

                            
                        }
                        else
                        {
                            city[people.PlacementX, people.PlacementY] = people.Name;
                        }

                       
                    }
                    if (people is Police)
                    {
                        if (city[(((Police)people).PlacementX), (((Police)people).PlacementY)] == "R")
                        {
                            foreach (Robber robber in robbers)
                            {
                                if (robber.PlacementX == (((Police)people).PlacementX) && robber.PlacementY == (((Police)people).PlacementY))
                                {
                                    if (robber.Thief == true)
                                    {
                                        stuff.TakeAllItems(robber.Loot, (((Police)people).StolenGoods));

                                        city[(((Police)people).PlacementX), (((Police)people).PlacementY)] = "[x]";
                                        robber.InPrison = true;
                                        Console.WriteLine("Thief Was Arrested");
                                        prison.prisoners.Add(robber);
                                        //robbers.Remove(robber);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Polis bumped in to thief with no stolen gods");
                                    }
                                    
                                }
                            }                
                            
                                                        
                        }
                        else
                        {
                            city[people.PlacementX, people.PlacementY] = people.Name;
                        }
                    }


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
                Console.WriteLine("Citizen Robbed: " + stuff.robbed);
                Console.WriteLine("Thiefs Arrested: " + stuff.arrested);
                prison.ListPrisoners();
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
