using SortingMachine.Algorithms;
using System;

namespace SortingMachine.ConsoleApp
{
    public static partial class Display
    {
        public static void AsRowsChart(StatusEventArgs status)
        {
            foreach (var item in status.Data)
            {
                ConsoleExtensions.ClearCurrentLine();
                SetColors(status, item);
                var value = new string('■', item);
                Console.WriteLine($"  {value} ({item})");
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        private static void SetColors(StatusEventArgs status, int item)
        {
            if (status.CurrentProcess != ManagerProcessStatus.Idle)
            {
                if (item == status.CurrentItem)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = status.CurrentProcess switch
                    {
                        ManagerProcessStatus.Exchanged => ConsoleColor.DarkGreen,
                        _ => ConsoleColor.DarkGray
                    };
                }
                else if (item == status.ExchangedItem)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = status.CurrentProcess switch
                    {
                        ManagerProcessStatus.Exchanging => ConsoleColor.DarkGreen,
                        ManagerProcessStatus.Exchanged => ConsoleColor.DarkGray,
                        _ => ConsoleColor.Black
                    };
                }
            }
        }
    }
}
