using car_management_app.Models;
using car_management_app.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace car_management_app.ViewModels
{
    public class AjouterReservationViewModel : BaseViewModel
    {
        private readonly ReservationService _reservationService;

        public ObservableCollection<Voiture> Voitures { get; }
        public ObservableCollection<Client> Clients { get; }

        private Voiture _selectedVoiture;
        public Voiture SelectedVoiture
        {
            get => _selectedVoiture;
            set => SetProperty(ref _selectedVoiture, value);
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set => SetProperty(ref _selectedClient, value);
        }

        private DateTime _dateDebut = DateTime.Today;
        public DateTime DateDebut
        {
            get => _dateDebut;
            set => SetProperty(ref _dateDebut, value);
        }

        private DateTime _dateFin = DateTime.Today.AddDays(1);
        public DateTime DateFin
        {
            get => _dateFin;
            set => SetProperty(ref _dateFin, value);
        }

        public ICommand AjouterReservationCommand { get; }

        public event Action<Reservation> ReservationAjoutee;

        public AjouterReservationViewModel()
        {
            _reservationService = new ReservationService();
            Voitures = new ObservableCollection<Voiture>();
            Clients = new ObservableCollection<Client>();
            AjouterReservationCommand = new Command(async () => await AjouterReservation());
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                var voitures = await _reservationService.GetAllVoituresAsync();
                foreach (var voiture in voitures)
                    Voitures.Add(voiture);

                var clients = await _reservationService.GetAllClientsAsync();
                foreach (var client in clients)
                    Clients.Add(client);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", ex.Message, "OK");
            }
        }

        private async Task AjouterReservation()
        {
            if (SelectedVoiture == null || SelectedClient == null)
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Veuillez sélectionner une voiture et un client.", "OK");
                return;
            }

            var nouvelleReservation = new Reservation
            {
                VoitureId = SelectedVoiture.Id, 
                ClientId = SelectedClient.Id,   
                DateDebut = DateDebut.ToString("yyyy-MM-dd"),
                DateFin = DateFin.ToString("yyyy-MM-dd")
            };

            var success = await _reservationService.CreateReservationAsync(nouvelleReservation);

            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Succès", "Réservation ajoutée avec succès.", "OK");

                ReservationAjoutee?.Invoke(nouvelleReservation);

                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Impossible d'ajouter la réservation.", "OK");
            }
        }
    }

}
