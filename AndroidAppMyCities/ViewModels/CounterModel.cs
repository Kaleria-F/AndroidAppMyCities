using AndroidAppMyCities.Models;
using AndroidAppMyCities.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AndroidAppMyCities.ViewModels
{
    class CounterModel : BaseViewModel
    {
        //создать единственный экземпляр класса
        private static CounterModel instance;
        public static CounterModel GetInstance()
        {
            if (instance == null)
                instance = new CounterModel();
            return instance;
        }
        public int GetCount()
        {
            return DataStore.GetCityCount();
        }        
    }
}
