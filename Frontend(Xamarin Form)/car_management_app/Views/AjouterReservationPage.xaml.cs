using car_management_app.ViewModels;
using Xamarin.Forms;

namespace car_management_app.Views
{
    public partial class AjouterReservationPage : ContentPage
    {
        public AjouterReservationPage()
        {
            InitializeComponent();
            BindingContext = new AjouterReservationViewModel();
        }

    }
}
