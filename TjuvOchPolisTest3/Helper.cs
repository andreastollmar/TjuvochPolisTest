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
                { //code to print the city out on the terminal window
                    if (i == 0 || i == 25)
                    {
                        Console.Write("=");
                    }
                    else if (i > 25)
                    {
                        Console.Write(array[i, j]);
                    }
                    else if (j == 0 || j == 100)
                    {
                        Console.Write("|");
                    }
                    else if (array[i, j] == null)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        // Added Colors for the persones
                        if (array[i, j] == "P")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(array[i, j]);
                            Console.ResetColor();
                        }
                        else if (array[i, j] == "R")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(array[i, j]);
                            Console.ResetColor();
                        }
                        else if (array[i, j] == "C")
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(array[i, j]);
                            Console.ResetColor();
                        }
                        else if (array[i, j] == "*" || array[i, j] == "#")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(array[i, j]);
                            Console.ResetColor();
                        }                        
                        else
                        {
                            Console.Write(array[i, j]);
                        }
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
