using car_management_app.Models;
using car_management_app.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace car_management_app.ViewModels
{
    public class AjouterClientViewModel : BaseViewModel
    {
        private readonly ClientService _clientService;

        private string _nom;
        private string _prenom;
        private string _email;
        private string _telephone;

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

        public Command AjouterClientCommand { get; }

        public AjouterClientViewModel(ClientService clientService)
        {
            _clientService = clientService;
            AjouterClientCommand = new Command(async () => await OnAjouterClient());
        }

        private async Task OnAjouterClient()
        {
            if (string.IsNullOrWhiteSpace(Nom) || string.IsNullOrWhiteSpace(Prenom) ||
                string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Telephone))
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Tous les champs doivent être remplis.", "OK");
                return;
            }

            if (!IsValidEmail(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Veuillez entrer un email valide.", "OK");
                return;
            }

            var nouveauClient = new Client
            {
                Nom = Nom,
                Prenom = Prenom,
                Email = Email,
                Telephone = Telephone
            };

            var success = await _clientService.AjouterClientAsync(nouveauClient);

            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Succès", "Client ajouté avec succès.", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Une erreur s'est produite lors de l'ajout du client.", "OK");
            }
        }

        private bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) &&
                   email.Contains("@") &&
                   email.Contains(".");
        }
    }
}
