using System;
using System.Linq;

namespace SortingMachine
{
    public static class DataGenerator
    {
        public static int[] Random(int from, int to)
        {
            if (from < 1)
                from = 1;

            if (to <= from)
                from = to + 1;

            var random = new Random();
            var result = Enumerable
                .Range(from, to)
                .OrderBy(_ => random.Next())
                .ToArray();

            return result;
        }

        public static int[] Sample1()
        {
            return new int[] { 6, 23, 2, 51, 44, 8, 1, 16 };
        }

        public static int[] Sample2()
        {
            return new int[] { 40, 22, 11, 63, 3, 7, 23, 25, 84, 39, 72, 9, 2, 44, 56, 1 };
        }

        public static int[] Sample3()
        {
            return new int[] { 21, 53, 28, 4, 13, 96, 81, 29, 55, 73, 18, 77, 5, 1, 63, 8, 35, 43, 99, 100, 26, 67, 10 };
        }

    }
}
