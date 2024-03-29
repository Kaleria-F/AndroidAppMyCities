using AndroidAppMyCities.Models;

namespace AndroidAppMyCities
{
    //класс для хранения данных о городах в базе данных
    public class CityDatabase
    {
        public CityDatabase()
        {
            //конструктор класса CityDatabase

        }

        //конструктор класса CityDatabase с параметром пути к базе данных
        public CityDatabase(string databasePath)
        {
            
        }
      
        

        //метод для добавления города в базу данных
        public bool AddCity(City city)
        {
            return false;
        }
       

        //метод для получения города по имени
        public City GetCity(string name)
        {
            return null;
        }

        //метод для получения всех городов из базы данных
        public City[] GetCities()
        {
            return null;
        }

   

        //метод для получения всех городов из базы данных
        public City[] GetCities(string district, string name)
        {
            return null;
        }

        //метод для получения всех городов из базы данных

   
    }
}