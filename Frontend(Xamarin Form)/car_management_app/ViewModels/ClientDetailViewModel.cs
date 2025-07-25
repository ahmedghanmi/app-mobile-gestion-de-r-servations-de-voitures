using car_management_app.Models;
using car_management_app.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace car_management_app.ViewModels
{
    public class ClientDetailViewModel : BaseViewModel
    {
        private readonly ClientService _clientService;
        private int _id;
        private string _nom;
        private string _prenom;
        private string _email;
        private string _telephone;

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Nom
        {
            get => _nom;
            set => SetProperty(ref _nom, value);
        }

        public string Prenom
        {
            get => _prenom;
            set => SetProperty(ref _prenom, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Telephone
        {
            get => _telephone;
            set => SetProperty(ref _telephone, value);
        }

        public ICommand ModifierClientCommand { get; }
        public ICommand SupprimerClientCommand { get; }

        public ClientDetailViewModel(ClientService clientService, Client client)
        {
            _clientService = clientService;

            Id = client.Id;
            Nom = client.Nom;
            Prenom = client.Prenom;
            Email = client.Email;
            Telephone = client.Telephone;

            ModifierClientCommand = new Command(async () => await ModifierClient());
            SupprimerClientCommand = new Command(async () => await SupprimerClient());
        }

        private async Task ModifierClient()
        {
            if (string.IsNullOrWhiteSpace(Nom) || string.IsNullOrWhiteSpace(Prenom) ||
                string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Telephone))
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Tous les champs doivent être remplis.", "OK");
                return;
            }

            var clientModifie = new Client
            {
                Id = Id,
                Nom = Nom,
                Prenom = Prenom,
                Email = Email,
                Telephone = Telephone
            };

            var success = await _clientService.ModifierClientAsync(Id, clientModifie);

            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Succès", "Client modifié avec succès.", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Une erreur s'est produite lors de la modification du client.", "OK");
            }
        }

        private async Task SupprimerClient()
        {
            var confirmation = await Application.Current.MainPage.DisplayAlert("Confirmation",
                "Voulez-vous vraiment supprimer ce client ?", "Oui", "Non");

            if (!confirmation)
                return;

            var success = await _clientService.SupprimerClientAsync(Id);

            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Succès", "Client supprimé avec succès.", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Une erreur s'est produite lors de la suppression du client.", "OK");
            }
        }
    }
}
