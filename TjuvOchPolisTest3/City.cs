using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolisTest3
{
    internal class City
    {
        public static string[,] city = new string[28, 100];
        public static List<Robber> robbers = new List<Robber>();
        public static List<Citizen> citizens = new List<Citizen>();
        public static List<Police> polices = new List<Police>();
        Stuff stuff = new Stuff();
        Person person = new Person();
        Prison prison = new Prison();
        public static List<Person> persons = new List<Person>();
        Helper helper = new Helper();


        public void Start()
        {
            List();

            while (true)
            {
                for(int i = 0; i < persons.Count; i++)
                {
                    persons[i].Movement();

                    if (persons[i] is Citizen)
                    {
                        city[persons[i].PlacementX, persons[i].PlacementY] = persons[i].Name;
                    }
                    if (persons[i] is Robber && (((Robber)persons[i]).InPrison) == false)
                    {
                        if (city[(((Robber)persons[i]).PlacementX), (((Robber)persons[i]).PlacementY)] == "C")
                        {
                            foreach (Citizen citizen in citizens)
                            {
                                if (citizen.PlacementX == (((Robber)persons[i]).PlacementX) && citizen.PlacementY == (((Robber)persons[i]).PlacementY))
                                {
                                    stuff.StealItem(citizen.Belongings, (((Robber)persons[i]).Loot));
                                    (((Robber)persons[i]).Thief) = true;  
                                }
                            }

                            city[(((Robber)persons[i]).PlacementX), (((Robber)persons[i]).PlacementY)] = "[y]";

                            city[26, 0] = "Citizen was robbed!";
                            
                        }
                        else
                        {
                            city[persons[i].PlacementX, persons[i].PlacementY] = persons[i].Name;
                        }

                       
                    }
                    if (persons[i] is Police)
                    {
                        if (city[persons[i].PlacementX, persons[i].PlacementY] == "R")
                        {
                            for(int j = 0; j < robbers.Count; j++)
                            {
                                if ((robbers[j].PlacementX == persons[i].PlacementX) && (robbers[j].PlacementY == persons[i].PlacementY))
                                {
                                    if (robbers[j].Thief == true)
                                    {
                                        stuff.TakeAllItems(robbers[j].Loot, (((Police)persons[i]).StolenGoods));

                                        city[(((Police)persons[i]).PlacementX), (((Police)persons[i]).PlacementY)] = "[x]";
                                        robbers[j].InPrison = true;
                                        city[27, 0] = "Thief was arrested";

                                        Random rnd = new Random();
                                        robbers[j].PlacementY = rnd.Next(1, 11);
                                        robbers[j].PlacementX = rnd.Next(1, 11);
                                        prison.prisoners.Add(robbers[j]);
                                        robbers.Remove(robbers[j]);
                                        persons.Remove(robbers[j]);
                                    }

                                    
                                }
                            }                
                            
                                                        
                        }
                        else
                        {
                            city[persons[i].PlacementX, persons[i].PlacementY] = persons[i].Name;
                        }
                    }


                }
               
                helper.PrintArray(city);

                
                Console.WriteLine("Citizen Robbed: " + stuff.robbed);
                Console.WriteLine("Thiefs Arrested: " + stuff.arrested);
                Console.WriteLine(robbers.Count);
                Console.WriteLine(persons.Count);
                prison.ListPrisoners();                
                prison.StarPrison();
                if (city[26, 0] != null || city[27, 0] != null)
                {
                    Thread.Sleep(2000);
                }
                else
                {
                    Thread.Sleep(500);
                }
                Console.Clear();
                
                helper.ClearArray(city);


            }
            
        }

        public static void List()
        {
            for (int i = 0; i < 30; i++)
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
