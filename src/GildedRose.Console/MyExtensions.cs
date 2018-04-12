using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public static class MyExtensions
    {
        public static void Increase(this Item item, int val)
        {
            item.Quality = Math.Min(item.Quality + val, 50);
        }
        public static void Decrease(this Item item)
        {
            item.Quality = Math.Max(item.Quality - (item.SellIn > 0 ? 1 : 2), 0);
        }
    }
}
