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
        private int cityId;
        private string cityName;
        private string description;
        public int Id { get; set; }

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

        public int CityId
        {
            get
            {
                return cityId;
            }
            set
            {
                cityId = value;
                LoadCityId(value);
            }
        }

        private void LoadCityId(int value)
        {
            throw new NotImplementedException();
        }

        public async void LoadICityId(string cityId)
        {
            try
            {
                var city = await DataStore.GetICity(cityId);

                Name = city.Name;
                Description = city.Description;
                Id = city.Id;
            }
            catch (Exception)
            {
                Debug.WriteLine("Ошибка при загрузке города");
            }
        }
    }
}
