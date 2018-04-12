using System.Collections.Generic;

namespace GildedRose.Console.Interfaces
{
    internal interface IRepository<T>
    {
        void Generate();
        T GetItem(string name);
        List<T> GetAll();
    }
}