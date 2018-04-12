using GildedRose.Console.Interfaces;

namespace GildedRose.Console.Strategies
{
    class DefaultQualityStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            if(!item.Name.Contains("Sulfuras"))
            {
                item.Decrease();
            }
        }
    }
}
