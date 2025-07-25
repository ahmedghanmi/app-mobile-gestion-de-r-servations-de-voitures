using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using car_management_app.Models;
using car_management_app.Services;
using Xamarin.Forms;

namespace car_management_app.ViewModels
{
    public class ReservationDetailViewModel : BaseViewModel
    {
        private readonly ReservationService _reservationService;

        public ReservationDetailViewModel(Reservation reservation)
        {
            _reservationService = new ReservationService();
            CurrentReservation = reservation;

            ModifierReservationCommand = new Command(async () => await ModifierReservation());
            SupprimerReservationCommand = new Command(async () => await SupprimerReservation());

            LoadClientsAndVoitures();
        }

        public Reservation CurrentReservation { get; set; }

        public ObservableCollection<Voiture> Voitures { get; set; } = new ObservableCollection<Voiture>();
        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();

        private Voiture _selectedVoiture;
        public Voiture SelectedVoiture
        {
            get => _selectedVoiture;
            set
            {
                _selectedVoiture = value;
                CurrentReservation.VoitureId = value?.Id ?? 0; 
                OnPropertyChanged();
            }
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                CurrentReservation.ClientId = value?.Id ?? 0; 
                OnPropertyChanged();
            }
        }

        public ICommand ModifierReservationCommand { get; }
        public ICommand SupprimerReservationCommand { get; }

        private async void LoadClientsAndVoitures()
        {
            try
            {
                var voitures = await _reservationService.GetAllVoituresAsync();
                foreach (var voiture in voitures)
                {
                    Voitures.Add(voiture);
                }

                var clients = await _reservationService.GetAllClientsAsync();
                foreach (var client in clients)
                {
                    Clients.Add(client);
                }

                SelectedVoiture = Voitures.FirstOrDefault(v => v.Id == CurrentReservation.VoitureId);
                SelectedClient = Clients.FirstOrDefault(c => c.Id == CurrentReservation.ClientId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des données : {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Erreur", "Impossible de charger les données.", "OK");
            }
        }

        private async Task ModifierReservation()
        {
            try
            {
                var success = await _reservationService.UpdateReservationAsync(CurrentReservation);

                if (success)
                {
                    await Application.Current.MainPage.DisplayAlert("Succès", "Réservation modifiée avec succès.", "OK");
                    await Shell.Current.GoToAsync(".."); // Retour à la liste
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erreur", "Impossible de modifier la réservation.", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Erreur", "Une erreur s'est produite.", "OK");
            }
        }

        private async Task SupprimerReservation()
        {
            var confirm = await Application.Current.MainPage.DisplayAlert("Confirmation", "Voulez-vous vraiment supprimer cette réservation ?", "Oui", "Non");

            if (!confirm)
                return;

            try
            {
                var success = await _reservationService.DeleteReservationAsync(CurrentReservation.Id);

                if (success)
                {
                    await Application.Current.MainPage.DisplayAlert("Succès", "Réservation supprimée avec succès.", "OK");
                    await Shell.Current.GoToAsync(".."); 
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erreur", "Impossible de supprimer la réservation.", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Erreur", "Une erreur s'est produite.", "OK");
            }
        }
    }
}
