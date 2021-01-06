namespace SortingMachine.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleExtensions.Clear();
            while (true)
            {
                var data = Options.GetData();
                var algorithm = Options.GetAlgorithm();
                var sleepTime = Options.GetSleepTime();

                var manager = Options.GetManager(algorithm, data, sleepTime);
                manager.PerformAlgorithm();
            }
        }
    }
}
