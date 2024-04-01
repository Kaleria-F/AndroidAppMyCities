using AndroidAppMyCities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidAppMyCities.Services
{
    /// <summary>
    /// Класс MockDataStore для хранения данных о городах в списке.
    /// </summary>
    public class MockDataStore : IDataStore<City>
    {
        /// <summary>
        /// Список городов.
        /// </summary>
        readonly List<City> yourCities;
       /// <summary>
       /// Конструктор класса MockDataStore.
       /// </summary>
        public MockDataStore()
        {
            yourCities = new List<City>() { };
        }
        /// <summary>
        /// Метод AddCity для добавления нового города в список.
        /// </summary>
        /// <param name="city"> Объект типа City. </param>
        /// <returns> Возвращает true. </returns>
        public async Task<bool> AddCity(City city)
        {
            ///для добавления нового города в список
            yourCities.Add(city);
           
            return await Task.FromResult(true);
            
        }
        /// <summary>
        /// Метод GetICity для получения списка городов.
        /// </summary>
        /// <param name="forceRefresh"> Параметр для обновления списка городов. </param>
        /// <returns> Возвращает список городов. </returns>
        public async Task<IEnumerable<City>> GetICity(bool forceRefresh = false)
        {
            return await Task.FromResult(yourCities);
        }

        /// <summary>
        /// Метод GetICity для получения города по имени.
        /// </summary>
        /// <param name="name"> Название города. </param>
        /// <returns> Возвращает город. </returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<City> GetICity(string name)
        {
            throw new NotImplementedException();
        }
    }
}