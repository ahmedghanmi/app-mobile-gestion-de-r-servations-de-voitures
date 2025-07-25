using car_management_app.Services;
using car_management_app.ViewModels;  
using Xamarin.Forms;

namespace car_management_app.Views
{
    public partial class AjouterClientPage : ContentPage
    {
        public AjouterClientPage()
        {
            InitializeComponent();
            BindingContext = new AjouterClientViewModel(new ClientService()); 
        }
    }
}
