using System;
using System.Collections.Generic;
using System.IO;

namespace StringMatching
{
    class Program
    {
        static void Main(string[] args)
        {

                Console.WriteLine("Input main string");
                string str1 = Console.ReadLine();
                Console.WriteLine("Input searched string");
                string str2 = Console.ReadLine();

                    List<int> indexes = Search(str1, str2);

                    foreach (var i in indexes)
                        Console.WriteLine("Element znaleziono na pozycji: {0}", i);

                    Console.WriteLine("\n");
                

        }

        
    }
}
