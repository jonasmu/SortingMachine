using SortingMachine.Algorithms;
using System;

namespace SortingMachine.ConsoleApp
{
    public static class Options
    {
        public static int GetSleepTime()
        {
            while (true)
            {
                try
                {
                    Display.SleepTimeOptions();
                    var option = Console.ReadKey(true);
                    return option.Key switch
                    {
                        ConsoleKey.N => 0,
                        ConsoleKey.F => 50,
                        ConsoleKey.M => 175,
                        ConsoleKey.S => 400
                    };
                }
                catch
                {
                }
            }
        }

        public static IAlgorithm GetAlgorithm()
        {
            while (true)
            {
                try
                {
                    Display.AlgorithmOptions();
                    var option = Console.ReadKey(true);
                    return option.Key switch
                    {
                        ConsoleKey.B => new BubbleSort(),
                        ConsoleKey.S => new SelectionSort(),
                        ConsoleKey.I => new InsertionSort(),
                        ConsoleKey.M => new MergeSort()
                    };
                }
                catch (Exception ex)
                {
                }
            }
        }

        public static AlgorithmManager GetManager(IAlgorithm algorithm, int[] data, int sleepTime)
        {
            var manager = new AlgorithmManager(algorithm, data, sleepTime);
            manager.BeforePerform += (sender, status) => Display.Init(status);
            manager.Update += (sender, status) => Display.UpdateStatus(status);
            manager.Finished += (sender, status) => Display.Finished(status);
            return manager;
        }

        public static int[] GetData()
        {
            while (true)
            {
                try
                {
                    Display.DataOptions();
                    var option = Console.ReadKey(true);
                    switch (option.Key)
                    {
                        case ConsoleKey.R:
                            Console.Write("     [#] FROM --> ");
                            var from = ConsoleExtensions.ReadNumber();
                            Console.Write("     [#] TO   --> ");
                            var to = ConsoleExtensions.ReadNumber();
                            return DataGenerator.Random(from, to);

                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            return DataGenerator.Sample1();

                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            return DataGenerator.Sample2();

                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            return DataGenerator.Sample3();
                    }
                }
                catch
                {
                }
            }
        }
    }
}
