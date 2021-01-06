using System;

namespace SortingMachine.Algorithms
{
    public abstract class AlgorithmBase : IAlgorithm
    {
        private readonly ExchangeEventArgs _exchangingEventArgs;
        private readonly ExchangeEventArgs _exchangeEventArgs;

        public event EventHandler<int> Operating;
        public event EventHandler<ExchangeEventArgs> Exchanging;
        public event EventHandler<ExchangeEventArgs> Exchanged;

        public AlgorithmBase()
        {
            _exchangingEventArgs = new ExchangeEventArgs();
            _exchangeEventArgs = new ExchangeEventArgs();
        }

        public abstract string Name { get; }
        protected internal int[] Data { get; private set; }

        public void Perform(int[] data)
        {
            Data = data;
            Perform();
        }

        protected internal abstract void Perform();

        protected internal void ComputeCurrentOperation(int currentIndex)
        {
            Operating?.Invoke(this, Data[currentIndex]);
        }

        protected internal void ExchangeData(int currentIndex, int exchangeIndex)
        {
            _exchangingEventArgs.CurrentItem = Data[currentIndex];
            _exchangingEventArgs.ExchangedItem = Data[exchangeIndex];
            Exchanging?.Invoke(this, _exchangingEventArgs);

            var temporary = Data[currentIndex];
            Data[currentIndex] = Data[exchangeIndex];
            Data[exchangeIndex] = temporary;

            _exchangeEventArgs.CurrentItem = Data[currentIndex];
            _exchangeEventArgs.ExchangedItem = Data[exchangeIndex];
            Exchanged?.Invoke(this, _exchangeEventArgs);
        }
    }
}
