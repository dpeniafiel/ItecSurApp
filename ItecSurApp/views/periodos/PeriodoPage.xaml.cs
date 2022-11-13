using ItecSurApp.models;
using ItecSurApp.services;
using ItecSurApp.views.periodos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ItecSurApp
{
    public partial class PeriodoPage : ContentPage
    {
        private PeriodoService PeriodoService;
        public PeriodoPage()
        {
            InitializeComponent();
            PeriodoService = new PeriodoService();
            CargarDatos();
        }

        private async void CargarDatos()
        {
            try { 
                var datos = await PeriodoService.GetPeriodos();
                listRegistros.ItemsSource = new ObservableCollection<PeriodoModel>(datos);
            }catch(Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private void listRegistros_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new PeriodoActualizarEliminar((PeriodoModel)e.SelectedItem));
        }

        private void btnNuevo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PeriodoAgregar());
        }
    }
}
