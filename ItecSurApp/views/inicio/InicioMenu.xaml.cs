using ItecSurApp.views.carreras;
using ItecSurApp.views.jornadas;
using ItecSurApp.views.nivel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.inicio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioMenu : ContentPage
    {
        public InicioMenu()
        {
            InitializeComponent();
        }

        private async void btnPeriodo_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;

            await App.MasterDet.Detail.Navigation.PushAsync(new PeriodoPage());
        }

        private async void btnCarrera_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;

            await App.MasterDet.Detail.Navigation.PushAsync(new CarreraPage());
        }

        private async void btnNivel_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;

            await App.MasterDet.Detail.Navigation.PushAsync(new NivelPage());
        }

        private async void btnJornada_Clicked(object sender, EventArgs e)
        {
            App.MasterDet.IsPresented = false;

            await App.MasterDet.Detail.Navigation.PushAsync(new JornadaPage());
        }
    }
}