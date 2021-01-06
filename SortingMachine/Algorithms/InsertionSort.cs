namespace SortingMachine.Algorithms
{
    public class InsertionSort : AlgorithmBase
    {
        public override string Name => "Insertion Sort";

        protected internal override void Perform()
        {
            for (var i = 1; i < Data.Length; i++)
            {
                for (var j = i; j > 0; j--)
                {
                    var currentIndex = j;
                    var previousIndex = j - 1;

                    ComputeCurrentOperation(currentIndex);

                    if (Data[currentIndex] < Data[previousIndex])
                    {
                        ExchangeData(currentIndex, previousIndex);
                    }
                }
            }
        }
    }
}
