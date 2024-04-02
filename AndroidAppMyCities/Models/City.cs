using System;

namespace AndroidAppMyCities.Models
{
    /// <summary>
    /// Класс City для создания объектов городов.
    /// </summary>
    public class City
    {

        private static int _idCounter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Конструктор для создания объекта города.
        /// </summary>
        /// <param name="name">Название города</param>
        /// <param name="description">Описание города</param>
        public City(string name, string description)
        {
            Id = ++_idCounter;
            Name = name;
            Description = description;
        }

        public City() { }
    }
}