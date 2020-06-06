using Algo;
using Algo.Additional;
using Algorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StringMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "";
            var algorithm = new List<IAlgorithm>() { new MorrisPrattAlgo(), new ApostoplicoCroshemoreAlgo(), new TurboReverseFactorAlgo() };
            Stopwatch clock = new Stopwatch();
            TimeSpan time = new TimeSpan(0);

            try
            {
                for (int i = 1; i < 2; i++)
                {
                    using (StreamWriter writer = new StreamWriter($"result{i}.txt"))
                    {
                        str1 = "";
                        string[] inputData = File.ReadAllLines($"text{i}.txt");
                        string[] searchtData = File.ReadAllLines($"patterns{i}.txt");                      

                        Console.SetOut(writer);

                        foreach (var item in inputData)
                        {
                            str1 += item;
                        }

                        foreach (var algo in algorithm)
                        {
                            Console.WriteLine(algo.Name);
                            foreach (var pattern in searchtData)
                            {
                                List<int> indexes = null;
                                clock.Start();
                                for (int j = 0; j < 100; j++)
                                {
                                    indexes = algo.Search(str1, pattern);
                                }
                                clock.Stop();

                                time = clock.Elapsed;


                                Console.Write($"<<{pattern}>>:");
                                foreach (var pos in indexes)
                                    Console.Write(" " + pos);
                                Console.WriteLine("\n100 " + time);

                                clock.Reset();
                                time = TimeSpan.Zero;
                            }

                        }
                    }
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The wrong path to file.");
            }
            finally
            {
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
                Console.ReadKey();
            }
        }
    }
}
