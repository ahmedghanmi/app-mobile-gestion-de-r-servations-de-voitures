using car_management_app.Models;
using car_management_app.Services;
using car_management_app.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace car_management_app.ViewModels
{
    public class ClientViewModel
    {
        private readonly ClientService _clientService;
        public ObservableCollection<Client> Clients { get; set; }
        public ICommand AjouterClientCommand { get; }

        public ClientViewModel()
        {
            _clientService = new ClientService();
            Clients = new ObservableCollection<Client>();
            AjouterClientCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(AjouterClientPage)));
        }

        public async Task ChargerClientsAsync()
        {
            var clients = await _clientService.GetAllClientsAsync();
            Clients.Clear();
            foreach (var client in clients)
            {
                Clients.Add(client);
            }
        }
    }
}
