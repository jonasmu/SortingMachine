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
                Begin = 0,
                Middle = Data.Length / 2,
                End = Data.Length
            };
            SplitSortData(position);
        }

        private void SplitSortData(Position position)
        {
            if (position.End - position.Begin <= 1)
                return;
            SplitSortData(new Position
                {
                    Begin = position.Begin,
                    Middle = (position.Begin + position.Middle) / 2,
                    End = position.Middle
                }); // Divide parte izquierda de array
            SplitSortData(new Position
                {
                    Begin = position.Middle,
                    Middle = (position.End + position.Middle) / 2,
                    End = position.End
                }); // Divide parte derecha de array
            MergeData(position);
        }

        private void MergeData(Position position)
        {
            int initialIndex = position.Begin;
            int compareIndex = position.Middle;
            int[] dataCompare = (int[])Data.Clone();

            for (int index = position.Begin; index < position.End; index++)
            {
                ComputeCurrentOperation(index);
                if (compareIndex >= position.End)
                {
                    ExchangeData(index, initialIndex, dataCompare[initialIndex]);
                    initialIndex++;
                } 
                else if (initialIndex < position.Middle && dataCompare[initialIndex] < dataCompare[compareIndex]) 
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

        private class Position
        {
            public int Begin { get; set; }
            public int Middle { get; set; }
            public int End { get; set; }
        }
    }
}