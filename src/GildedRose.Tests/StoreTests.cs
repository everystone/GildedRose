using GildedRose.Console;
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

        }

        [Fact]
        public void BackStagePasses()
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