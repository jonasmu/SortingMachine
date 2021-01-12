using System;
using System.Collections.Generic;
using System.Text;

namespace SortingMachine.Algorithms
{
    public class MergeSort : AlgorithmBase
    {
        public override string Name => "Merge Sort";

        protected internal override void Perform()
        {
            Position position = new Position
            {
                begin = 0,
                middle = Data.Length / 2,
                end = Data.Length
            };
            SplitSortData(position);
        }

        private void SplitSortData(Position position)
        {
            if (position.end - position.begin <= 1)
                return;
            Position leftPosition, rigthPosition;
            leftPosition.begin = position.begin;
            leftPosition.middle = (position.begin + position.middle) / 2;
            leftPosition.end = position.middle;
            rigthPosition.begin = position.middle;
            rigthPosition.middle = (position.end + position.middle) / 2;
            rigthPosition.end = position.end;

            SplitSortData(leftPosition); // Divide parte izquierda de array
            SplitSortData(rigthPosition); // Divide parte derecha de array
            MergeData(position);
        }

        private void MergeData(Position position)
        {
            int initialIndex = position.begin;
            int compareIndex = position.middle;
            int[] dataCompare = (int[])Data.Clone();

            for (int index = position.begin; index < position.end; index++)
            {
                ComputeCurrentOperation(index);
                if (compareIndex >= position.end)
                {
                    ExchangeData(index, initialIndex, dataCompare[initialIndex]);
                    initialIndex++;
                } 
                else if (initialIndex < position.middle && dataCompare[initialIndex] < dataCompare[compareIndex]) 
                {
                    ExchangeData(index, initialIndex, dataCompare[initialIndex]);
                    initialIndex++;
                }
                else
                {
                    ExchangeData(index, compareIndex, dataCompare[compareIndex]);
                    compareIndex++;
                }
            }
        }

        private struct Position
        {
            public int begin;
            public int middle;
            public int end;
        }
    }
}