using car_management_app.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace car_management_app.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
