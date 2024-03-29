using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndroidAppMyCities.Services
{
    //интерфейс для хранения данных о городах
    public interface IDataStore<T>
    {
        Task<bool> AddCity(T city);
        Task<bool> UpdateDescription(T city);
        Task<bool> DeleteCity(string name); 
        Task<T> GetICity(string name);

        //для получения всех городов из списка
        Task<IEnumerable<T>> GetICity(bool forceRefresh = false);
    }
}
