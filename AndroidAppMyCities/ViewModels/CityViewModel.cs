using AndroidAppMyCities.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AndroidAppMyCities.ViewModels
{
    [QueryProperty(nameof(CityId), nameof(CityId))]

    public class CityViewModel : BaseViewModel
    {
        private string cityId;
        private string cityName;
        private string description;
        public string Id { get; set; }

        public string Name
        {
            get => cityName;
            set => SetProperty(ref cityName, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string CityId
        {
            get
            {
                return cityId;
            }
            set
            {
                cityId = value;
                LoadICityId(value);
            }
        }

        public async void LoadICityId(string cityId)
        {
            try
            {
                var city = await DataStore.GetICity(cityId);
                Id = city.Id;
                Name = city.Name;
                Description = city.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load city");
            }
        }
    }
}
