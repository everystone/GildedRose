using GildedRose.Console.Interfaces;

namespace GildedRose.Console.Strategies
{
    class AgedBrieStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.Increase(item.SellIn < 1 ? 2 : 1);
        }
    }
}
