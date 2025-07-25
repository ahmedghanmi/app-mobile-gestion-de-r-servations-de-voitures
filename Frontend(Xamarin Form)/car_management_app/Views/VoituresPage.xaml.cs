using car_management_app.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using car_management_app.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace car_management_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VoituresPage : ContentPage
    {
        private VoitureViewModel _viewModel;

        public VoituresPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as VoitureViewModel;
        }
         private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            var voiture = e.Item as Voiture;

            await Navigation.PushAsync(new VoitureDetailPage(voiture));

            ((ListView)sender).SelectedItem = null;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.ChargerVoituresAsync();
        }
    }
}