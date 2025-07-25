using Xamarin.Forms;
using car_management_app.ViewModels;
using car_management_app.Models;
using car_management_app.Services;

namespace car_management_app.Views
{
    [QueryProperty(nameof(ReservationId), "reservationId")]
    public partial class ReservationDetailPage : ContentPage
    {
        private int _reservationId;

        public string ReservationId
        {
            set
            {
                if (int.TryParse(value, out var id))
                {
                    _reservationId = id;
                    LoadReservationDetails();
                }
            }
        }

        public ReservationDetailPage()
        {
            InitializeComponent();
        }

        private async void LoadReservationDetails()
        {
            var service = new ReservationService();
            var reservation = await service.GetReservationByIdAsync(_reservationId);

            if (reservation != null)
            {
                BindingContext = new ReservationDetailViewModel(reservation);
            }
            else
            {
                await DisplayAlert("Erreur", "Réservation introuvable.", "OK");
                await Shell.Current.GoToAsync("..");
            }
        }

    }
}
