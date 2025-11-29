using car_management_app.Models;
using car_management_app.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace car_management_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VoitureDetailPage : ContentPage
    {
        private readonly VoitureService _voitureService;
        public Voiture Voiture { get; set; }

        public VoitureDetailPage(Voiture voiture)
        {
            InitializeComponent();
            _voitureService = new VoitureService();
            Voiture = voiture; 
            BindingContext = Voiture; 
        }

        // Méthode pour modifier la voiture
        private async void OnModifierClicked(object sender, EventArgs e)
        {
            var success = await _voitureService.ModifierVoitureAsync(Voiture.Id, Voiture);

            if (success)
            {
                await DisplayAlert("Succès", "La voiture a été modifiée avec succès.", "OK");
            }
            else
            {
                await DisplayAlert("Erreur", "La modification a échoué.", "OK");
            }
        }
    

        private async void OnSupprimerClicked(object sender, EventArgs e)
        {
            var confirmation = await DisplayAlert("Confirmer", "Êtes-vous sûr de vouloir supprimer cette voiture ?", "Oui", "Non");

            if (confirmation)
            {
                var success = await _voitureService.SupprimerVoitureAsync(Voiture.Id);

                if (success)
                {
                    await DisplayAlert("Succès", "La voiture a été supprimée.", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Erreur", "La suppression a échoué.", "OK");
                }
            }
        }
    }
}