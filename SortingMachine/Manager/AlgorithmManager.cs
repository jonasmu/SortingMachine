using System;
using System.Diagnostics;
using System.Threading;

namespace SortingMachine.Algorithms
{
    public class AlgorithmManager : IAlgorithmManager
    {
        private readonly IAlgorithm _algorithm;
        private readonly int[] _data;
        private readonly Stopwatch _stopwatch;
        private readonly StatusEventArgs _statusEventArgs;
        private readonly int _sleepTime;

        public event EventHandler<StatusEventArgs> BeforePerform;
        public event EventHandler<StatusEventArgs> Update;
        public event EventHandler<StatusEventArgs> Finished;

        public AlgorithmManager(IAlgorithm algorithm, int[] data, int sleepTime = 0)
        {
            _stopwatch = new Stopwatch();
            _algorithm = algorithm;
            _algorithm.Operating += OnOperating;
            _algorithm.Exchanging += OnExchanging;
            _algorithm.Exchanged += OnExchanged;
            _data = data;
            _sleepTime = sleepTime;
            _statusEventArgs = new StatusEventArgs(algorithm.Name, data, _stopwatch);
        }
        public string AlgorithmName => _algorithm.Name;

        private void OnOperating(object sender, int currentItem)
        {
            _statusEventArgs.CurrentProcess = ManagerProcessStatus.Operating;

            _statusEventArgs.CurrentItem = currentItem;
            _statusEventArgs.Operations++;
            Update?.Invoke(this, _statusEventArgs);
            Thread.Sleep(_sleepTime);
        }

        private void OnExchanging(object sender, ExchangeEventArgs args)
        {
            _statusEventArgs.CurrentProcess = ManagerProcessStatus.Exchanging;

            _statusEventArgs.CurrentItem = args.CurrentItem;
            _statusEventArgs.ExchangedItem = args.ExchangedItem;
            Update?.Invoke(this, _statusEventArgs);
            Thread.Sleep(_sleepTime);
        }

        private void OnExchanged(object sender, ExchangeEventArgs args)
        {
            _statusEventArgs.CurrentProcess = ManagerProcessStatus.Exchanged;

            _statusEventArgs.CurrentItem = args.CurrentItem;
            _statusEventArgs.ExchangedItem = args.ExchangedItem;
            Update?.Invoke(this, _statusEventArgs);
            Thread.Sleep(_sleepTime);

            _statusEventArgs.CurrentProcess = ManagerProcessStatus.Idle;
            Update?.Invoke(this, _statusEventArgs);
            Thread.Sleep(_sleepTime);
        }

        public void PerformAlgorithm()
        {
            _statusEventArgs.CurrentProcess = ManagerProcessStatus.Idle;
            BeforePerform?.Invoke(this, _statusEventArgs);
            _stopwatch.Restart();

            _algorithm.Perform(_data);

            _stopwatch.Stop();
            _statusEventArgs.CurrentProcess = ManagerProcessStatus.Idle;
            Finished?.Invoke(this, _statusEventArgs);
        }
    }
}
