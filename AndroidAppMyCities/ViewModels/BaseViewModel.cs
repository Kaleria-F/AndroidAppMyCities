using AndroidAppMyCities.Models;
using AndroidAppMyCities.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace AndroidAppMyCities.ViewModels
{

//базовый класс для всех ViewModel
    public class BaseViewModel : INotifyPropertyChanged
    {
        //свойство DataStore типа IDataStore<City> для доступа к данным о городах
        public IDataStore<City> DataStore => DependencyService.Get<IDataStore<City>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        //метод SetProperty<T> для установки значения свойства и вызова события PropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

       
        
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion // INotifyPropertyChanged - это интерфейс, который предоставляет уведомление об изменениях, произошедших в свойстве объекта.
    }
}
