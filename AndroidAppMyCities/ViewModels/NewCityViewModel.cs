﻿using AndroidAppMyCities.Models;
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
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(description);
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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // Это удаляет текущую страницу из стека навигации
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            City newItem = new City()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Description = Description
            };

            await DataStore.AddCity(newItem);

            // Это удаляет текущую страницу из стека навигации
            await Shell.Current.GoToAsync("..");
        }
    }
}
