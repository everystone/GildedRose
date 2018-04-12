using GildedRose.Console.Interfaces;

namespace GildedRose.Console.Strategies
{
    class BackStagePassStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
                return;
            }

            if (item.SellIn < 6)
            {
                item.Increase(3);
            }
            else if (item.SellIn < 11)
            {
                item.Increase(2);
            }
            else
            {
                item.Increase(1);
            }
        }
    }
}
