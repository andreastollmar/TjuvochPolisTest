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
        public string[,] prison = new string[10, 10];
        

        public void ListPrisoners()
        {
            Console.WriteLine("==============================================\n");
            Console.WriteLine(prisoners.Count);

        }

        public void StarPrison()
        {
            for(int i = 0; i < prison.GetLength(0); i++)
            {
                for(int j = 0; j < prison.GetLength(1); j++)
                {
                    if(prison[i,j] != null)
                    {
                        Console.Write(prison[i,j]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
        }




       

    }
}
