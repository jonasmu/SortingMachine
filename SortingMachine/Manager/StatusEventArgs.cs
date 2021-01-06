using System;
using System.Diagnostics;

namespace SortingMachine.Algorithms
{
    public class StatusEventArgs : EventArgs
    {
        private Stopwatch _stopwatch;

        public StatusEventArgs(string name, int[] data, Stopwatch stopwatch)
        {
            AlgorithmName = name;
            Data = data;
            _stopwatch = stopwatch;
        }

        public string AlgorithmName { get; private set; }
        public int[] Data { get; private set; }
        public int? CurrentItem { get; internal set; }
        public int? ExchangedItem { get; internal set; }
        public int Operations { get; internal set; }
        public TimeSpan ElapsedTime => _stopwatch.Elapsed;
        public bool IsRunning => _stopwatch.IsRunning;
        public ManagerProcessStatus CurrentProcess { get; internal set; }
    }
}
