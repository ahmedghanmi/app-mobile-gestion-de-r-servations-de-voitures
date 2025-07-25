using car_management_app.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace car_management_app.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}