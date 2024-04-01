using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndroidAppMyCities.Services
{
    /// <summary>
    /// Интерфейс IDataStore, представляющий методы для работы с данными.
    /// </summary>
    /// <typeparam name="T">Тип объектов, который будет хранится. </typeparam>
    public interface IDataStore<T>
    {
        Task<bool> AddCity(T city);
        Task<bool> UpdateDescription(T city);
        Task<bool> DeleteCity(string name);
        Task<T> GetICity(string name);
        Task<IEnumerable<T>> GetICity(bool forceRefresh = false);

    }
}
