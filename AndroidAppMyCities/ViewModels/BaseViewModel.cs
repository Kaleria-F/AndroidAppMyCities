using AndroidAppMyCities.Models;
using AndroidAppMyCities.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace AndroidAppMyCities.ViewModels
{
    /// <summary>
    /// Класс BaseViewModel для управления свойствами и событиями.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
       /// <summary>
       /// Поле DataStore для хранения данных о городах.
       /// </summary>
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
        /// <summary>
        /// Метод SetProperty для установки значения свойства
        /// </summary>
        /// <typeparam name="T"> Тип свойства. </typeparam>
        /// <param name="backingStore"> Поле для хранения значения свойства. </param>
        /// <param name="value"> Новое значение свойства. </param>
        /// <param name="propertyName"> Имя свойства. </param>
        /// <param name="onChanged"> Действие, которое будет выполнено при изменении свойства. </param>
        /// <returns></returns>
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
