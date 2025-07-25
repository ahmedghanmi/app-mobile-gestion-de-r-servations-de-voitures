using car_management_app.Models;
using car_management_app.Services;
using car_management_app.ViewModels;
using System.Windows.Input;
using Xamarin.Forms;

namespace car_management_app.Views
{
    public partial class ClientDetailPage : ContentPage
    {
        public ICommand RetourCommand { get; }

        public ClientDetailPage(Client client)
        {
            InitializeComponent();

            BindingContext = client;
            BindingContext = new ClientDetailViewModel(new ClientService(), client);
            RetourCommand = new Command(async () =>
            {
                await Navigation.PopAsync(); // Revenir à la page précédente
            });
        }
    }
}
