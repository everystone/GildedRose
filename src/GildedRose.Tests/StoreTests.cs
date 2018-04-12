using GildedRose.Console;
using System.Linq;
using Xunit;

namespace GildedRose.Tests
{

    public class StoreTest: IClassFixture<StoreFixture>
    {
        private StoreFixture _fixture;
        protected Store Store => _fixture.Store;

        protected void SkipDays(int days)
        {
            for(var i=0;i<days;i++)
            {
                Store.UpdateQuality();
            }
        }


        public StoreTest(StoreFixture fix)
        {
            this._fixture = fix;
            _fixture.Reset();
        }

        [Fact]
        public void InitialQuality()
        {
            Assert.Equal(Store.GetItem("Aged Brie").Quality, 0);
            Assert.Equal(Store.GetItem("Sulfuras").Quality, 80);
            Assert.Equal(Store.GetItem("Backstage").Quality, 20);
            Assert.Equal(Store.GetItem("Vest").Quality, 20);
        }
        [Fact]
        public void PricesAfterOneDay()
        {
            SkipDays(1);
            Assert.Equal(Store.GetItem("Aged Brie").Quality, 1);
            Assert.Equal(Store.GetItem("Sulfuras").Quality, 80);
            Assert.Equal(Store.GetItem("Backstage").Quality, 21);
            Assert.Equal(Store.GetItem("Vest").Quality, 19);
        }
        [Fact]
        public void BrieShouldIncreaseInQuality()
        {
            Assert.Equal(Store.GetItem("Aged Brie").Quality, 0);
            SkipDays(5);
            Assert.Equal(Store.GetItem("Aged Brie").Quality, 8);
        }

        [Fact]
        public void SulfurasShouldNotDegrade()
        {
            Assert.Equal(Store.GetItem("Sulfuras").Quality, 80);
            SkipDays(50);
            Assert.Equal(Store.GetItem("Sulfuras").Quality, 80);
        }

        [Fact]
        public void QualityDegradesTwiceAfterSellDate()
        {
            var item = Store.GetItem("Vest");
            Assert.Equal(item.Quality, 20);
            SkipDays(item.SellIn);
            Assert.Equal(item.Quality, 10);
            SkipDays(1);
            Assert.Equal(item.Quality, 8);
            SkipDays(1);
            Assert.Equal(item.Quality, 6);
        }

        [Fact]
        public void QualityShouldNotGoNegative()
        {
            SkipDays(100);
            var items = Store.GetAllItems();
            items.ForEach(i => Assert.True(i.Quality >= 0));
        }
        [Fact]
        public void QualityShouldNotBeAbove50ExceptSulfuras()
        {
            SkipDays(100);
            var items = Store.GetAllItems().Where(i => !i.Name.Contains("Sulfuras")).ToList();
            items.ForEach(i => Assert.True(i.Quality <= 50));
        }
        [Fact]
        public void BackStagePassesIncreasesInQualityUntilConcert()
        {
            var pass = Store.GetItem("Backstage");
            Assert.Equal(pass.Quality, 20);

            Store.UpdateQuality();
            Assert.Equal(pass.Quality, 21);
            SkipDays(10);
            Assert.Equal(pass.Quality, 38);
            Assert.Equal(pass.SellIn, 4);
            SkipDays(4);
            Assert.Equal(pass.Quality, 50);
            SkipDays(1);
            Assert.Equal(pass.Quality, 0);
        }
    }
}