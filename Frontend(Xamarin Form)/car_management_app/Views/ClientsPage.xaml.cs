using car_management_app.Models;
using car_management_app.ViewModels;
using Xamarin.Forms;

namespace car_management_app.Views
{
    public partial class ClientsPage : ContentPage
    {
        private ClientViewModel _viewModel;

        public ClientsPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as ClientViewModel;

        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            var client = e.Item as Client;
            await Navigation.PushAsync(new ClientDetailPage(client));

            ((ListView)sender).SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.ChargerClientsAsync();
        }
    }
}
