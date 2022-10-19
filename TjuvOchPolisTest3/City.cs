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
                    if (persons[i] is Robber)
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

                            Console.WriteLine("Citizen was robbed!");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            city[persons[i].PlacementX, persons[i].PlacementY] = persons[i].Name;
                        }

                       
                    }
                    if (persons[i] is Police)
                    {
                        if (city[(((Police)persons[i]).PlacementX), (((Police)persons[i]).PlacementY)] == "R")
                        {
                            for(int j = 0; j < robbers.Count; j++)
                            {
                                if ((robbers[j].PlacementX == (((Police)persons[i]).PlacementX) && (robbers[j].PlacementY == ((Police)persons[i]).PlacementY)))
                                {
                                    if (robbers[j].Thief == true)
                                    {
                                        stuff.TakeAllItems(robbers[j].Loot, (((Police)persons[i]).StolenGoods));

                                        city[(((Police)persons[i]).PlacementX), (((Police)persons[i]).PlacementY)] = "[x]";
                                        robbers[j].InPrison = true;
                                        Console.WriteLine("Thief Was Arrested");
                                        Thread.Sleep(2000);

                                        Random rnd = new Random();
                                        robbers[j].PlacementY = rnd.Next(1, 11);
                                        robbers[j].PlacementX = rnd.Next(1, 11);
                                        prison.prisoners.Add(robbers[j]);
                                        persons.Remove(robbers[j]);
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
                            city[persons[i].PlacementX, persons[i].PlacementY] = persons[i].Name;
                        }
                    }


                }
               
                helper.PrintArray(city);

                
                Console.WriteLine("Citizen Robbed: " + stuff.robbed);
                Console.WriteLine("Thiefs Arrested: " + stuff.arrested);
                prison.ListPrisoners();                
                prison.StarPrison();
                Thread.Sleep(500);
                Console.Clear();
                
                helper.ClearArray(city);


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
