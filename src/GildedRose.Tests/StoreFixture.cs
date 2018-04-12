using GildedRose.Console;
using System;

namespace GildedRose.Tests
{
    public class StoreFixture: IDisposable
    {
        public Store Store;
        public void Reset()
        {
            Store = new Store();
        }

        public void Dispose()
        {
            Store = null;
        }
    }
}