using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolisTest3
{
    internal class City
    {
        public static string[,] city = new string[29, 101];
        public List<Person> prisonersfreed = new List<Person>();
        public static List<Robber> robbers = new List<Robber>();
        public static List<Citizen> citizens = new List<Citizen>();
        public static List<Police> polices = new List<Police>();
        Stuff stuff = new Stuff();        
        Prison prison = new Prison();
        public static List<Person> persons = new List<Person>();
        Helper helper = new Helper();


        public void Start()
        {
           
            List();
            //Long metod to print members into matris city and handle collisions
            while (true)
            {
                //Checking each Person for subclasses and doing different things depending on subclass
                for (int i = 0; i < persons.Count; i++)
                {
                    persons[i].Movement();

                    if (persons[i] is Citizen)
                    {
                        city[persons[i].PlacementX, persons[i].PlacementY] = persons[i].Name;
                    }
                    if (persons[i] is Robber && (((Robber)persons[i]).InPrison) == false)
                    {
                        //checking if there is a citizen in the spot where robber gonna walk
                        if (city[(((Robber)persons[i]).PlacementX), (((Robber)persons[i]).PlacementY)] == "C")
                        {
                            //Finding that exact citizen
                            foreach (Citizen citizen in citizens)
                            {
                                if (citizen.PlacementX == (((Robber)persons[i]).PlacementX) && citizen.PlacementY == (((Robber)persons[i]).PlacementY))
                                {
                                    //thief steal a random item and get the bool Thief == true
                                    stuff.StealItem(citizen.Belongings, (((Robber)persons[i]).Loot));
                                    (((Robber)persons[i]).Thief) = true;  
                                }
                            }

                            city[(((Robber)persons[i]).PlacementX), (((Robber)persons[i]).PlacementY)] = "#";
                            //Hardcoded event into the matris
                            city[27, 1] = "Citizen was robbed!";
                            
                        }
                        else
                        {
                            city[persons[i].PlacementX, persons[i].PlacementY] = persons[i].Name;
                        }

                       
                    }
                    if (persons[i] is Police)
                    {
                        //checking if there is a robber in place where Polis is added.
                        if (city[persons[i].PlacementX, persons[i].PlacementY] == "R")
                        {
                            for(int j = 0; j < robbers.Count; j++)
                            {   //Finding that exakt robber                          
                                if ((robbers[j].PlacementX == persons[i].PlacementX) && (robbers[j].PlacementY == persons[i].PlacementY))
                                {
                                    //Checking if the robber is a thief
                                    if (robbers[j].Thief == true)
                                    {
                                        int prisontime = robbers[j].Loot.Count;
                                        stuff.TakeAllItems(robbers[j].Loot, (((Police)persons[i]).StolenGoods));

                                        city[(((Police)persons[i]).PlacementX), (((Police)persons[i]).PlacementY)] = "*";
                                        //robber get bool inPrison
                                        robbers[j].InPrison = true;
                                        //printing out the event on the matris
                                        city[28, 1] = "Thief was arrested";
                                        robbers[j].TimeInPrison = 10 + (2 * prisontime);
                                        Random rnd = new Random();
                                        robbers[j].PlacementY = rnd.Next(1, 11);
                                        robbers[j].PlacementX = rnd.Next(1, 11);
                                        prison.prisoners.Add(robbers[j]);
                                        robbers.Remove(robbers[j]);                                                                               
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

                //Method to print array                
                helper.PrintArray(city);


                //Printing data in bottom of matris                
                Console.WriteLine("Citizens Robbed: " + stuff.robbed);
                Console.WriteLine("Thiefs Arrested: " + stuff.arrested);                
                //Prison metods                
                prison.ListPrisoners();                
                prison.StartPrison();

                //thread sleep implement for auto updates
                if (city[27, 1] != null || city[28, 1] != null)
                {
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Thread.Sleep(500);                    
                }

                //Console.Clear();
                Console.SetCursorPosition(0, 0);

                //metod to clear array
                helper.ClearArray(city);
            }            
        }
        //metod to creat the lists of people for the city matris
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
        public static void AddPrisonerToList(Robber person)
        {
            robbers.Add(person);
        }
    }

}
