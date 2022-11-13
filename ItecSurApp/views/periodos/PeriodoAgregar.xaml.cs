using ItecSurApp.models;
using ItecSurApp.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.periodos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeriodoAgregar : ContentPage
    {
        PeriodoService periodoService;
        public PeriodoAgregar()
        {
            InitializeComponent();
            periodoService = new PeriodoService();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try { 
            PeriodoModel periodoModel = new PeriodoModel();
            periodoModel.nombre= txtNombre.Text;
            periodoModel.fecha_inicio = txtFechaInicio.Date.ToString("yyyy-MM-dd");
            periodoModel.fecha_fin = txtFechaFin.Date.ToString("yyyy-MM-dd");
            periodoModel.estado = "ACTIVO";
            await periodoService.PostPeriodo(periodoModel);
            await DisplayAlert("CORRECTO", "Registro ingresado con éxito", "Aceptar");
            await Navigation.PushAsync(new PeriodoPage());
            }
            catch(Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PeriodoPage());
        }
    }
}