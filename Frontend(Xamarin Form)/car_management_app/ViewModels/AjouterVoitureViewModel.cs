using car_management_app.Models;
using car_management_app.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace car_management_app.ViewModels
{
    public class AjouterVoitureViewModel : BindableObject
    
    {
        private string _marque;
        private string _modele;
        private int _annee;
        private decimal _prix;

        private readonly VoitureService _voitureService;

        public string Marque
        {
            get => _marque;
            set
            {
                _marque = value;
                OnPropertyChanged();
            }
        }

        public string Modele
        {
            get => _modele;
            set
            {
                _modele = value;
                OnPropertyChanged();
            }
        }

        public int Annee
        {
            get => _annee;
            set
            {
                _annee = value;
                OnPropertyChanged();
            }
        }

        public decimal Prix
        {
            get => _prix;
            set
            {
                _prix = value;
                OnPropertyChanged();
            }
        }

        public ICommand AjouterCommand { get; }

        public AjouterVoitureViewModel()
        {
            _voitureService = new VoitureService();
            AjouterCommand = new Command(async () => await AjouterVoiture());
        }

        private async Task AjouterVoiture()
        {
            if (string.IsNullOrWhiteSpace(Marque) || string.IsNullOrWhiteSpace(Modele) || Annee <= 0 || Prix <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Veuillez remplir tous les champs correctement.", "OK");
                return;
            }

            var nouvelleVoiture = new Voiture
            {
                Marque = Marque,
                Modele = Modele,
                Annee = Annee,
                Prix = Prix
            };

            var success = await _voitureService.AjouterVoitureAsync(nouvelleVoiture);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Succès", "La voiture a été ajoutée avec succès.", "OK");
                await Shell.Current.GoToAsync(".."); 
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Une erreur s'est produite lors de l'ajout de la voiture.", "OK");
            }
        }
    }

}