using car_management_app.Services;
using car_management_app.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace car_management_app
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
    }
}
