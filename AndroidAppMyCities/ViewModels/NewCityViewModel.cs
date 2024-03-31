using AndroidAppMyCities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AndroidAppMyCities.ViewModels
{
    public class NewICityViewModel : BaseViewModel
    {
        private string name;
        private string description;

        public NewICityViewModel()
        {
            SaveCommand = new Command(OnSave); //вызов метода OnSave при нажатии на кнопку
            CancelCommand = new Command(OnCancel); //вызов метода OnCancel при нажатии на кнопку
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute(); //проверка на возможность нажатия кнопки
        }



        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; } //команда для кнопки сохранения
        public Command CancelCommand { get; } //команда для кнопки отмены

        private async void OnCancel()
        {
            // Это удаляет текущую страницу из стека навигации
            await Shell.Current.GoToAsync("..");
        }

        //тут изменить способ добавления (сюда будет поступать из поисковика)
        private async void OnSave() //метод для сохранения данных
        {
            City newItem = new City() //создание нового экземпляра класса City
            {
                Name = Name, //передача названия города
                Description = Description //передача описания города
            };

            await DataStore.AddCity(newItem);

            // Это удаляет текущую страницу из стека навигации
            await Shell.Current.GoToAsync("..");
        }
    }
}
