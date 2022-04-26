using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Avion
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AvionsMainPage avionsMainPage = new AvionsMainPage();
            MainPage = new NavigationPage(avionsMainPage);
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
