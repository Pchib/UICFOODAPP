using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UICFOODAPP.Services;
using UICFOODAPP.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UICFOODAPP.Views
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Username;
        public string Username
        {
            set
            {
                this._Username = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Username;
            }
        }
        private string _Password;
        public string Password
        {
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Password;
            }
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }
            get
            {
                return this._IsBusy;
            }
        }

     

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }
        public bool Result { get; private set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());

        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {

                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Password);
                
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Success", "User Registered", "OK");
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "User already Exists with this credentials", "OK");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Password);
                var Result2 = Result.ToString();
                _ = Application.Current.MainPage.DisplayAlert("Success", Result2, "OK");
                if (Result)
                {
                    Preferences.Set("Username", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "Invaild Username or Password", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

   

        



}
