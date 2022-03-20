using System;
using UICFoodOrderApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UICFOODAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();
           //LoginView = new Log
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
