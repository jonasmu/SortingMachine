using System;

namespace SortingMachine.Algorithms
{
    public class ExchangeEventArgs : EventArgs
    {
        public int CurrentItem { get; set; }
        public int ExchangedItem { get; set; }
    }
}
