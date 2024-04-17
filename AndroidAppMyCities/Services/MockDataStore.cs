using AndroidAppMyCities.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

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
        static string fileName1 = "list_of_cities_and_memories.xml";
        private string filePath1 = Path.Combine(FileSystem.AppDataDirectory, fileName1);

        /// <summary>
        /// Конструктор класса MockDataStore.
        /// </summary>
        public MockDataStore()
        {
            yourCities = new List<City>() { };
            LoadFile();
            if (Application.Current.Properties.ContainsKey("AppLaunchedBefore"))
            {
                LoadCities();
            }
            else
            {
                Application.Current.Properties["AppLaunchedBefore"] = true;
            }
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

            SaveCities();

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

        public int GetCityCount()
        {
            return yourCities.GroupBy(x => x.Name).Count();
        }
        public void LoadFile()
        {
            if (!File.Exists(filePath1))
            {
                // Создание файла
                File.Create(filePath1).Dispose();
            }
        }

        private void LoadCities()
        {
            if (File.Exists(filePath1))
            {
                XDocument doc = XDocument.Load(filePath1);
                yourCities.Clear();

                var cityElements = doc.Element("Cities").Elements("City");

                if (cityElements.Any())
                {
                    foreach (XElement cityElement in cityElements)
                    {
                        City city = new City
                        {
                            Name = cityElement.Element("Name").Value,
                            Description = cityElement.Element("Description").Value
                        };
                        yourCities.Add(city);
                    }
                }
            }
        }

        private void SaveCities()
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("Cities");
            doc.Add(root);

            foreach (City city in yourCities)
            {
                root.Add(
                    new XElement("City",
                        new XElement("Name", city.Name),
                        new XElement("Description", city.Description)
                    )
                );
            }

            doc.Save(filePath1);
        }
    }
}