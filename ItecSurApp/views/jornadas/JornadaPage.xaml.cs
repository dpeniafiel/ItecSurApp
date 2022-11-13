using ItecSurApp.models;
using ItecSurApp.services;
using ItecSurApp.views.jornadas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.jornadas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JornadaPage : ContentPage
    {
        private JornadaService JornadaService;
        public JornadaPage()
        {
            InitializeComponent();
            JornadaService = new JornadaService();
            CargarDatos();
        }

        private async void CargarDatos()
        {
            try
            {
                var datos = await JornadaService.GetJornadas();
                listRegistros.ItemsSource = new ObservableCollection<JornadaModel>(datos);
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private void listRegistros_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new JornadaActualizarEliminar((JornadaModel)e.SelectedItem));
        }

        private void btnNuevo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JornadaAgregar());
        }
    }
}