using SortingMachine.Algorithms;
using System;
using System.Linq;

namespace SortingMachine.ConsoleApp
{
    public static partial class Display
    {
        public static void Init(StatusEventArgs status)
        {
            ConsoleExtensions.Clear();

            Console.WriteLine($"----------------\n");
            Console.WriteLine($"    {status.AlgorithmName}\n");
            Console.WriteLine($"----------------\n");
            Console.WriteLine("Press any key to start the algorithm...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void DataOptions()
        {
            ConsoleExtensions.Clear();
            Console.WriteLine($"--------------------------\n");
            Console.WriteLine($"    DATA GENERATION\n");
            Console.WriteLine($"--------------------------\n");
            Console.WriteLine("   R) Random numbers from a custom range");
            Console.WriteLine("   1) Sample 1");
            Console.WriteLine("   2) Sample 2");
            Console.WriteLine("   2) Sample 3");
        }

        public static void SleepTimeOptions()
        {
            ConsoleExtensions.Clear();
            Console.WriteLine($"--------------------------\n");
            Console.WriteLine($"    SLEEP TIME\n");
            Console.WriteLine($"--------------------------\n");
            Console.WriteLine("   N) No sleep time");
            Console.WriteLine("   F) Fast");
            Console.WriteLine("   M) Medium");
            Console.WriteLine("   S) Slow");
        }

        public static void AlgorithmOptions()
        {
            ConsoleExtensions.Clear();
            Console.WriteLine($"--------------------------\n");
            Console.WriteLine($"    SORTING ALGORITHMS\n");
            Console.WriteLine($"--------------------------\n");
            var algorithmNames = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IAlgorithm).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x.Name)
                .ToList();

            algorithmNames.ForEach(x => Console.WriteLine($"   {char.ToUpper(x[0])}) {x}"));
        }

        public static void UpdateStatus(StatusEventArgs status)
        {
            Console.SetCursorPosition(0, 0);
            Display.AsRowsChart(status);

            Console.WriteLine($" * ALGORITHM: {status.AlgorithmName}");

            Console.ForegroundColor = status.CurrentProcess switch
            {
                ManagerProcessStatus.Operating => ConsoleColor.DarkYellow,
                ManagerProcessStatus.Exchanging => ConsoleColor.Yellow,
                ManagerProcessStatus.Exchanged => ConsoleColor.Yellow,
                _ => ConsoleColor.DarkGray
            };
            ConsoleExtensions.ClearCurrentLine();
            Console.WriteLine($" * PROCESS: {status.CurrentProcess}");
            Console.ResetColor();

            Console.WriteLine($" * OPERATIONS: {status.Operations}");
        }

        public static void Finished(StatusEventArgs status)
        {
            ConsoleExtensions.Clear();
            UpdateStatus(status);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nAlgorithm finished!");
            Console.WriteLine($"TOTAL TIME: {status.ElapsedTime}");
            Console.WriteLine("Press any key to continue...");
            Console.ResetColor();

            Console.ReadKey();
            ConsoleExtensions.Clear();
        }
    }
}
