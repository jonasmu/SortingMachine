namespace SortingMachine.Algorithms
{
    public class SelectionSort : AlgorithmBase
    {
        public override string Name => "Selection Sort";

        protected internal override void Perform()
        {
            for (var i = 0; i < Data.Length - 1; i++)
            {
                var currentIndex = i;
                var minValueIndex = GetMinValue(i);

                if (currentIndex != minValueIndex)
                {
                    ExchangeData(currentIndex, minValueIndex, Data[minValueIndex]);
                }
            }
        }

        private int GetMinValue(int start)
        {
            var min = start;
            for (int i = start + 1; i < Data.Length; i++)
            {
                ComputeCurrentOperation(start);

                if (Data[i] < Data[min])
                    min = i;
            }
            return min;
        }
    }
}
