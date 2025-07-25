using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace car_management_app.ViewModels
{
   public class AboutViewModel : BaseViewModel
    {
        public ICommand GererVoituresCommand { get; }
        public ICommand GererClientsCommand { get; }
        public ICommand GererReservationsCommand { get; }
        public ICommand AboutCommand { get; }
        public ICommand ContactCommand { get; }

        public AboutViewModel()
        {
            GererClientsCommand = new Command(async () => await Shell.Current.GoToAsync("ClientsPage"));
            GererVoituresCommand = new Command(async () => await Shell.Current.GoToAsync("VoituresPage"));
            GererReservationsCommand = new Command(async () => await Shell.Current.GoToAsync("ReservationListPage"));
            AboutCommand = new Command(() => App.Current.MainPage.DisplayAlert("À propos", "Cette application gère les voitures.", "OK"));
            ContactCommand = new Command(() => App.Current.MainPage.DisplayAlert("Contact", "Email: support@example.com", "OK"));
        }
    }
}