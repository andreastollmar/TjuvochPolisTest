using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolisTest3
{
    internal class Prison
    {
        public List<Person> prisoners = new List<Person>();
        public string[,] prison = new string[11, 11];
        Helper helper = new Helper();
        Robber robber = new Robber();        
        

        public void ListPrisoners() //Method for the prisoners
        {
            Console.WriteLine("=====================\n");
            Console.WriteLine("Robbers in prison: " + prisoners.Count); //number of arrested
            Console.WriteLine();

        }

        public void StartPrison()
        {
            //code to add all prisoners to the prison matris
            foreach (Person prisoner in prisoners)
            {
                prison[prisoner.PlacementX, prisoner.PlacementY] = prisoner.Name;
                (((Robber)prisoner).TimeInPrison)--;
                prisoner.Movement();
            }
            for (int i = 0; i < prisoners.Count; i++)
            {
                if (((Robber)prisoners[i]).TimeInPrison < 0 )
                {
                    ((Robber)prisoners[i]).Thief = false;
                    ((Robber)prisoners[i]).InPrison = false;
                    City.AddPrisonerToList(((Robber)prisoners[i]));
                    prisoners.RemoveAt(i);
                }
            }

            //code to print the prison out on the terminal window
            for(int i = 0; i < prison.GetLength(0); i++)
            {
                for(int j = 0; j < prison.GetLength(1); j++)
                {
                    if (i == 0 || i == 10)
                    {
                        Console.Write("=");
                    }
                    else if(j == 0 || j == 10)
                    {
                        Console.Write("|");
                    }
                    else if (prison[i, j] == null)
                    {
                        Console.Write(" ");
                    }
                    else if (prison[i, j] == "R")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(prison[i, j]);
                        Console.ResetColor();
                    }
                    else
                    {

                        Console.Write(prison[i, j]);
                    }

                }
                Console.WriteLine();
            }
            //metod to clear matris
            helper.ClearArray(prison);            

        }




       

    }
}
