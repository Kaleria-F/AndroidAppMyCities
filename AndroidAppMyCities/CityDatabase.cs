using AndroidAppMyCities.Models;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;
using System.Reflection;
using System.Xml.Linq;

namespace AndroidAppMyCities
{
    //класс для хранения данных о городах в базе данных
    public class CityDatabase
    {
   
        private List<string> citiesNames;
        private static CityDatabase instance;
        

        public CityDatabase()
        {
            citiesNames = new List<string>();
            LoadCitiesFromFile("cities.xml");
        }

        public static CityDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CityDatabase();
                }
                return instance;
            }
        }

        public void LoadCitiesFromFile(string filePath)
        {
            var resourceName = "AndroidAppMyCities.cities.xml";
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                XDocument xdoc = XDocument.Load(reader);

                citiesNames = xdoc.Descendants("Name")
                   .Select(element => element.Value)
                   .ToList();
            }

        }

        //метод для получения списка имен городов из базы данных
        public List<string> GetCitiesNames()
        {
            return citiesNames;
                       
        }
    }
}