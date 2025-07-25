using car_management_app.ViewModels;
using car_management_app.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace car_management_app
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(VoituresPage), typeof(Views.VoituresPage));
            Routing.RegisterRoute(nameof(ClientsPage), typeof(Views.ClientsPage));
            Routing.RegisterRoute(nameof(VoitureDetailPage), typeof(VoitureDetailPage));
            Routing.RegisterRoute(nameof(AjouterVoiturePage), typeof(AjouterVoiturePage));
            Routing.RegisterRoute(nameof(AjouterClientPage), typeof(AjouterClientPage));
            Routing.RegisterRoute(nameof(AjouterReservationPage), typeof(AjouterReservationPage));
            Routing.RegisterRoute(nameof(ReservationDetailPage), typeof(ReservationDetailPage));
            Routing.RegisterRoute(nameof(ReservationListPage), typeof(ReservationListPage));



        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
