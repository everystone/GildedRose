using GildedRose.Console.Interfaces;
using GildedRose.Console.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    class ItemQualityService : IItemQualityService
    {
        private Dictionary<string, IUpdateQualityStrategy> _strategies = new Dictionary<string, IUpdateQualityStrategy>()
        {
            {"Aged Brie", new AgedBrieStrategy() },
            {"Backstage passes to a TAFKAL80ETC concert", new BackStagePassStrategy() },
            {"Default", new DefaultQualityStrategy() },
            {"Conjured Mana Cake", new ConjuredItemsStrategy()}
        };


        public void UpdateItem(Item item)
        {
            var strategy = _strategies.ContainsKey(item.Name) ? _strategies[item.Name] : _strategies["Default"];
            strategy.UpdateQuality(item);
            if(!item.Name.Contains("Sulfuras"))
            {
                item.SellIn -= 1;
            }
        }

        //public void _UpdateItem(Item item)
        //{
        //    if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
        //    {
        //        if (item.Quality > 0)
        //        {
        //            if (item.Name != "Sulfuras, Hand of Ragnaros")
        //            {
        //                item.Quality = item.Quality - 1;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (item.Quality < 50)
        //        {
        //            item.Quality = item.Quality + 1;

        //            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
        //            {
        //                if (item.SellIn < 11)
        //                {
        //                    if (item.Quality < 50)
        //                    {
        //                        item.Quality = item.Quality + 1;
        //                    }
        //                }

        //                if (item.SellIn < 6)
        //                {
        //                    if (item.Quality < 50)
        //                    {
        //                        item.Quality = item.Quality + 1;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    if (item.Name != "Sulfuras, Hand of Ragnaros")
        //    {
        //        item.SellIn = item.SellIn - 1;
        //    }

        //    if (item.SellIn < 0)
        //    {
        //        if (item.Name != "Aged Brie")
        //        {
        //            if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
        //            {
        //                if (item.Quality > 0)
        //                {
        //                    if (item.Name != "Sulfuras, Hand of Ragnaros")
        //                    {
        //                        item.Quality = item.Quality - 1;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                item.Quality = item.Quality - item.Quality;
        //            }
        //        }
        //        else
        //        {
        //            if (item.Quality < 50)
        //            {
        //                item.Quality = item.Quality + 1;
        //            }
        //        }
        //    }
            
        //}
    }
}
