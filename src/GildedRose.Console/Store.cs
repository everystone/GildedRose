using GildedRose.Console.Interfaces;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Store
    {
        private IRepository<Item> _repository;
        private IItemQualityService _qualityService;

        public Store()
        {
            _repository = new ItemRepository();
            _repository.Generate();
            _qualityService = new ItemQualityService();
        }

        public void UpdateQuality()
        {
            _repository.GetAll().ForEach(i => _qualityService.UpdateItem(i));
        }

        public Item GetItem(string name) => _repository.GetItem(name);
        public List<Item> GetAllItems() => _repository.GetAll();
    }
}
