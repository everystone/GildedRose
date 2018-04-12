namespace GildedRose.Console
{
    class ItemQualityService : IItemQualityService
    {

        private void UpdateBackStagePases(Item item)
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
            } else
            {
                item.Increase(1);
            }

            

        }
        public void UpdateItem(Item item)
        {
            switch(item.Name)
            {
                case "Aged Brie":
                    item.Increase(item.SellIn < 1 ? 2 : 1);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateBackStagePases(item);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    item.Decrease();
                    break;
            }

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
