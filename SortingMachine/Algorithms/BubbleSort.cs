using System;

namespace SortingMachine.Algorithms
{
    public class BubbleSort : AlgorithmBase
    {
        public override string Name => "Bubble Sort";

        protected internal override void Perform()
        {
            for (var i = Data.Length - 1; i > 0; i--)
            {
                for (var j = 0; j < i; j++)
                {
                    var currentIndex = j;
                    var nextIndex = j + 1;

                    ComputeCurrentOperation(currentIndex);

                    if (Data[currentIndex] > Data[nextIndex])
                    {
                        ExchangeData(currentIndex, nextIndex);
                    }
                }
            }
        }
    }
}
