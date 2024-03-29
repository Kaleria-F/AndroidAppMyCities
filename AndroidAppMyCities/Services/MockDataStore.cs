using AndroidAppMyCities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidAppMyCities.Services
{
    //класс для хранения данных о городах в виде списка
    public class MockDataStore : IDataStore <City>
    {
        readonly List<City> items;

        public MockDataStore()
        {
            items = new List<City>()
            {
                new City { Id = Guid.NewGuid().ToString(), Name = "Пример", Description="Мой первый город" },
            };
        }

        public async Task<bool> AddCity(City city)
        {
            ///для добавления нового города в список
            items.Add(city);

            return await Task.FromResult(true);
        }

       //для обновления описания города в списке
        public async Task<bool> UpdateDescription(City city)
        {
            var oldItem = items.Where((City arg) => arg.Id == city.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(city);

            return await Task.FromResult(true);
        }

        //для удаления города из списка
        public async Task<bool> DeleteCity(string id)
        {
            var oldItem = items.Where((City arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        //для получения города по id
        public async Task<City> GetICity(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        //для получения всех городов
        public async Task<IEnumerable<City>> GetICity(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}