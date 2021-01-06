using System;

namespace SortingMachine.Algorithms
{
    public interface IAlgorithmManager
    {
        event EventHandler<StatusEventArgs> BeforePerform;
        event EventHandler<StatusEventArgs> Update;
        event EventHandler<StatusEventArgs> Finished;

        string AlgorithmName { get; }

        void PerformAlgorithm();
    }
}
