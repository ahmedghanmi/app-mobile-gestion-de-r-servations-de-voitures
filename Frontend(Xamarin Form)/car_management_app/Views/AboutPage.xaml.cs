using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace car_management_app.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        private async void OnGererVoituresClicked(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync("VoituresPage");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", $"Une erreur s'est produite : {ex.Message}", "OK");
                Console.WriteLine(ex); 
            }
        }
        private async void OnGererClientsClicked(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync("ClientsPage");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", $"Une erreur s'est produite : {ex.Message}", "OK");
                Console.WriteLine(ex); 
            }
        }
    }
}