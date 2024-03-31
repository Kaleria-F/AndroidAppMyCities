using AndroidAppMyCities.Models;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;
using System.Reflection;

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
            LoadCitiesFromFile("citiesFordDB.csv");
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
            var resourceName = "AndroidAppMyCities.citiesFordDB.csv";
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                //string result = reader.ReadToEnd();

                if (reader != null)
                {
                    using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
                    {
                        while (csv.Read())
                        {
                            citiesNames.Add(file[1]);
                        }
                    }
                }

            }
        }

        //метод для получения списка имен городов из базы данных
        public List<string> GetCitiesNames()
        {
            return citiesNames;
                       
        }
    }
}