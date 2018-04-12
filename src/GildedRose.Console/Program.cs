using System.Collections.Generic;

namespace GildedRose.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var store = new Store();
            store.UpdateQuality();

            System.Console.ReadKey();

        }
    }
}
