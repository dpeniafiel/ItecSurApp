
using ItecSurApp.GenerateExcel;
using ItecSurApp.models;
using ItecSurApp.views.inicio;
using ItecSurApp.views.jornadas;
using ItecSurApp.views.login;
using ItecSurApp.views.nivel;
using ItecSurApp.views.usuarios;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDet { get; set; }

        public static List<PermisoModel> Permisos= new List<PermisoModel>();

        public static UsuarioModel Usuario;

        public static PerfilModel Perfil;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
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
