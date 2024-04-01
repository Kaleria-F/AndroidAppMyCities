using AndroidAppMyCities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidAppMyCities.Services
{
    //класс для хранения данных о городах в виде списка
    public class MockDataStore : IDataStore<City>
    {
        readonly List<City> yourCities;


        public MockDataStore()
        {
            yourCities = new List<City>() { };
        }

        public async Task<bool> AddCity(City city)
        {
            ///для добавления нового города в список
            yourCities.Add(city);
            return await Task.FromResult(true);
        }

        //для обновления описания города в списке
        public async Task<bool> UpdateDescription(City city)
        {
            var oldItem = yourCities.Where((City arg) => arg.Id == city.Id).FirstOrDefault();
            yourCities.Remove(oldItem);
            yourCities.Add(city);
            
            
            
            return await Task.FromResult(true);
        }

        //для удаления города из списка
        public async Task<bool> DeleteCity(int id)
        {
            var oldItem = yourCities.Where((City arg) => arg.Id == id).FirstOrDefault();
            yourCities.Remove(oldItem);

            return await Task.FromResult(true);
        }

        //для получения всех городов
        public async Task<IEnumerable<City>> GetICity(bool forceRefresh = false)
        {
            return await Task.FromResult(yourCities);
        }

        //для удаления города по имени
        public Task<bool> DeleteCity(string name)
        {
            throw new NotImplementedException();
        }

        //для получения города по имени
        public Task<City> GetICity(string name)
        {
            throw new NotImplementedException();
        }

        //для получения количиства городов с уникальным именем в списке городов
        public int GetCountCity()
        {
            return yourCities.Select(city => city.Name).Count();
        }
    }
}