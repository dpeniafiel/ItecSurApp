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
    }
}