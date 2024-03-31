using System;

namespace AndroidAppMyCities.Models
{
    public class City
    {

        private static int _idCounter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string District { get; set; }


        public City(string name, string district)
        {
            Id = ++_idCounter;
            Name = name;
            District = district;
            Description = string.Empty;
        }

        //конструктор по умолчанию -удалить потом
        public City()
        {
            Id = ++_idCounter;
            Name = string.Empty;
            District = string.Empty;
            Description = string.Empty;
        }
    }
}