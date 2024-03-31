using System;

namespace AndroidAppMyCities.Models
{
    public class City
    {

        private static int _idCounter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public City(string name, string description)
        {
            Id = ++_idCounter;
            Name = name;
            Description = description;
        }

        public City()
        {
        }
    }
}