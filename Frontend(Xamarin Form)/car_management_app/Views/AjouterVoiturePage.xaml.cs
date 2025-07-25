using car_management_app.ViewModels;
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
    public partial class AjouterVoiturePage : ContentPage
    {
        public AjouterVoiturePage()
        {
            InitializeComponent();
            BindingContext = new AjouterVoitureViewModel();

        }
    }
}