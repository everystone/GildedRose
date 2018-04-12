using GildedRose.Console.Interfaces;

namespace GildedRose.Console.Strategies
{
    class ConjuredItemsStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            item.Decrease();
            item.Decrease();
        }
    }
}
