using ItecSurApp.views.inicio;
using ItecSurApp.views.jornadas;
using ItecSurApp.views.login;
using ItecSurApp.views.nivel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDet { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new JornadaPage());
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
