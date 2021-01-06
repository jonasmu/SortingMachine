using System;

namespace SortingMachine.Algorithms
{
    public interface IAlgorithm
    {
        string Name { get; }

        event EventHandler<int> Operating;
        event EventHandler<ExchangeEventArgs> Exchanging;
        event EventHandler<ExchangeEventArgs> Exchanged;

        void Perform(int[] data);
    }
}
