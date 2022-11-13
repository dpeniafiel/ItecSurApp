using ItecSurApp.models;
using ItecSurApp.services;
using ItecSurApp.views.niveles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.nivel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NivelPage : ContentPage
    {
        private NivelService NivelService;
        public NivelPage()
        {
            InitializeComponent();
            NivelService = new NivelService();
            CargarDatos();
        }

        private async void CargarDatos()
        {
            try
            {
                var datos = await NivelService.GetNiveles();
                listRegistros.ItemsSource = new ObservableCollection<NivelModel>(datos);
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private void listRegistros_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new NivelActualizarEliminar((NivelModel)e.SelectedItem));
        }

        private void btnNuevo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NivelAgregar());
        }

    }
}