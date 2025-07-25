using car_management_app.Models;
using car_management_app.Services;
using car_management_app.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace car_management_app.ViewModels
{
    public class VoitureViewModel
    {
        private readonly VoitureService _voitureService;
        public ObservableCollection<Voiture> Voitures { get; set; }
        public ICommand AjouterVoitureCommand { get; }
        public ICommand ModifierVoitureCommand { get; }
        public ICommand SupprimerVoitureCommand { get; }

        public VoitureViewModel()
        {
            _voitureService = new VoitureService();
            Voitures = new ObservableCollection<Voiture>();

            AjouterVoitureCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(AjouterVoiturePage)));

          
        }

        public async Task ChargerVoituresAsync()
        {
            var voitures = await _voitureService.GetAllVoituresAsync();
            Voitures.Clear();
            foreach (var voiture in voitures)
            {
                Voitures.Add(voiture);
            }
        }
    }
}
