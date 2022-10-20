using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolisTest3
{
    internal class Helper
    {
        //Print array method
        public void PrintArray(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if(i == 0 || i == 25 )
                    {
                        Console.Write("=");
                    }
                    else if(j == 0 || j == 100 )
                    {
                        Console.Write("|");
                    }
                    else if (array[i, j] == null)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(array[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
        //clear array method
        public void ClearArray(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = null;
                }
            }
        }
    }
}
