using AndroidAppMyCities.Services;
using AndroidAppMyCities.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidAppMyCities
{
    public partial class App : Application
    {
        private static CityDatabase database;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new Menu();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
           
        }

        //подключение к базе данных cities.db 
        public static CityDatabase Database
        {
            get
            {
                if (database == null)
                {
                    //путь по которому будет создана база данных 
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cities.db");

                    //проверяем существует ли файл по данному пути
                    if (!File.Exists(dbPath))
                    {
                        // получаем текущую сборку
                        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                        // получаем поток ресурсов
                        Stream stream = assembly.GetManifestResourceStream("AndroidAppMyCities.cities.db");
                        // создаем файл
                        FileStream fileStream = File.Create(dbPath);
                        // копируем поток в файл
                        stream.CopyTo(fileStream);
                        fileStream.Close();
                    }
                    database = new CityDatabase(dbPath);
                                    
                }
                return database;
            }
        }   
    }
}
