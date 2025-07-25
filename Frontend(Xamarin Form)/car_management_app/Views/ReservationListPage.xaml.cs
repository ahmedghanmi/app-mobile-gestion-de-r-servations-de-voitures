using car_management_app.ViewModels;
using System;
using Xamarin.Forms;

namespace car_management_app.Views
{
    public partial class ReservationListPage : ContentPage
    {
        public ReservationListPage()
        {
            InitializeComponent();
            BindingContext = new ReservationListViewModel();  
        }
        private async void OnReservationSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Reservation selectedReservation)
            {
                await Shell.Current.GoToAsync($"{nameof(ReservationDetailPage)}?reservationId={selectedReservation.Id}");
                ((ListView)sender).SelectedItem = null; 
            }
        }
        private void OnVoitureSelected(object sender, EventArgs e)
        {
            var viewModel = (ReservationListViewModel)BindingContext;
            viewModel.OnVoitureSelected();
        }

        private void OnClientSelected(object sender, EventArgs e)
        {
            var viewModel = (ReservationListViewModel)BindingContext;
            viewModel.OnClientSelected();
        }

    }
}
