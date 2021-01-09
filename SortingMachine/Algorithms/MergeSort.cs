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
            int[] compareData = CreateCompareData();
            Position position = new Position
            {
                Begin = 0,
                Middle = Data.Length / 2,
                End = Data.Length
            };
            SplitSortData(Data, compareData, position);
        }

        private void SplitSortData(int[] data, int[] compareData, Position position)
        {
            if (position.End - position.Begin <= 1)
                return;
            SplitSortData(compareData, data,
                new Position
                {
                    Begin = position.Begin,
                    Middle = (position.Begin + position.Middle) / 2,
                    End = position.Middle
                }); // Divide parte izquierda de array
            SplitSortData(compareData, data,
                new Position
                {
                    Begin = position.Middle,
                    Middle = (position.End + position.Middle) / 2,
                    End = position.End
                }); // Divide parte derecha de array
            MergeData(data, compareData, position);
        }

        private void MergeData(int[] data, int[] compareData, Position position)
        {
            int initialIndex = position.Begin;
            int compareIndex = position.Middle;

            for (int index = position.Begin; index < position.End; index++)
            {
                if (compareIndex >= position.End)
                {
                    data[index] = compareData[initialIndex];
                    initialIndex++;
                    continue;
                } 
                if (initialIndex < position.Middle && compareData[initialIndex] < compareData[compareIndex]) 
                {
                    data[index] = compareData[initialIndex];
                    initialIndex++;
                }
                else
                {
                    data[index] = compareData[compareIndex];
                    compareIndex++;
                }
                ComputeCurrentOperation(index);
            }
        }

        private int[] CreateCompareData()
        {
            int dataLength = Data.Length;
            int[] compareData = new int[dataLength];
            for (int dataIndex = 0; dataIndex < dataLength; dataIndex++)
                compareData[dataIndex] = Data[dataIndex];
            return compareData;
        }

        private class Position
        {
            public int Begin { get; set; }
            public int Middle { get; set; }
            public int End { get; set; }
        }
    }
}