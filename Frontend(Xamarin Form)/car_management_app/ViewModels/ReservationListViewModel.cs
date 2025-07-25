using System;
using System.Collections.ObjectModel;
using System.Linq;
using car_management_app.Models;
using car_management_app.Services;
using car_management_app.Views;
using Xamarin.Forms;

namespace car_management_app.ViewModels
{
    public class ReservationListViewModel : BaseViewModel
    {
        private readonly ReservationService _reservationService;
        public ObservableCollection<Reservation> Reservations { get; }
        public ObservableCollection<Voiture> Voitures { get; }
        public ObservableCollection<Client> Clients { get; }

        private Voiture _selectedVoiture;
        private Client _selectedClient;

        public Command AjouterReservationCommand { get; }

        public Voiture SelectedVoiture
        {
            get => _selectedVoiture;
            set
            {
                SetProperty(ref _selectedVoiture, value);
                OnVoitureSelected();
            }
        }

        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                SetProperty(ref _selectedClient, value);
                OnClientSelected();
            }
        }

        public ReservationListViewModel()
        {
            _reservationService = new ReservationService();
            Reservations = new ObservableCollection<Reservation>();
            Voitures = new ObservableCollection<Voiture>();
            Clients = new ObservableCollection<Client>();
            AjouterReservationCommand = new Command(OnAjouterReservation);

            // Charger les voitures et les clients
            LoadVoitures();
            LoadClients();
            LoadReservations();
        }

        private async void LoadReservations()
        {
            try
            {
                var reservations = await _reservationService.GetAllReservationsAsync();
                Console.WriteLine($"Réservations chargées : {reservations.Count}");

                Reservations.Clear();
                foreach (var reservation in reservations)
                {
                    Reservations.Add(reservation);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des réservations : {ex.Message}");
                await App.Current.MainPage.DisplayAlert("Erreur", "Impossible de charger les réservations.", "OK");
            }
        }


        private async void LoadVoitures()
        {
            try
            {
                var voitures = await _reservationService.GetAllVoituresAsync();
                foreach (var voiture in voitures)
                {
                    Voitures.Add(voiture);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des voitures : {ex.Message}");
            }
        }

        private async void LoadClients()
        {
            try
            {
                var clients = await _reservationService.GetAllClientsAsync();
                foreach (var client in clients)
                {
                    Clients.Add(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des clients : {ex.Message}");
            }
        }

        public void OnVoitureSelected()
        {
            if (SelectedVoiture != null)
            {
                var filteredReservations = Reservations.Where(r => r.VoitureId == SelectedVoiture.Id).ToList();
                Reservations.Clear();
                foreach (var reservation in filteredReservations)
                {
                    Reservations.Add(reservation);
                }
            }
        }

        public void OnClientSelected()
        {
            if (SelectedClient != null)
            {
                // Vérifiez l'ID du client sélectionné
                Console.WriteLine($"Client sélectionné: {SelectedClient.Id}, {SelectedClient.Nom}");

                var filteredReservations = Reservations.Where(r => r.ClientId == SelectedClient.Id).ToList();
                Reservations.Clear();

                if (filteredReservations.Any())
                {
                    foreach (var reservation in filteredReservations)
                    {
                        Reservations.Add(reservation);
                    }
                }
                else
                {
                    Console.WriteLine("Aucune réservation trouvée pour ce client.");
                }
            }
            else
            {
                Console.WriteLine("Aucun client sélectionné.");
            }
        }

        private async void OnAjouterReservation()
        {
            try
            {
                var ajouterReservationPage = new AjouterReservationPage();
                var viewModel = (AjouterReservationViewModel)ajouterReservationPage.BindingContext;

                viewModel.ReservationAjoutee += OnReservationAjoutee;

                await Shell.Current.GoToAsync(nameof(AjouterReservationPage));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la navigation : {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Erreur", "Impossible d'ouvrir la page d'ajout.", "OK");
            }
        }

        private void OnReservationAjoutee(Reservation nouvelleReservation)
        {
            Reservations.Add(nouvelleReservation);
        }
    }
}
