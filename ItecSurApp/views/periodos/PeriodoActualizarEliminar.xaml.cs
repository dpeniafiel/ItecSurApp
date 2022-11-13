using ItecSurApp.models;
using ItecSurApp.services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.periodos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeriodoActualizarEliminar : ContentPage
    {
        private PeriodoModel periodoModel;
        private PeriodoService periodoService;
        public PeriodoActualizarEliminar(PeriodoModel periodoModel)
        {
            InitializeComponent();
            this.periodoModel = periodoModel;
            this.periodoService = new PeriodoService();
            CargarRegistroSeleccionado();
        }

        private void CargarRegistroSeleccionado()
        {
            try
            {
                txtCodigo.Text = periodoModel.codigo.ToString();
                txtNombre.Text = periodoModel.nombre;
                var fechaInicio = DateTime.ParseExact(periodoModel.fecha_inicio, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                txtFechaInicio.Date = fechaInicio;
                var fechaFin = DateTime.ParseExact(periodoModel.fecha_fin, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                txtFechaFin.Date = fechaFin;
                cmbEstado.SelectedItem = periodoModel.estado;
            }
            catch (Exception)
            {
                DisplayAlert("ADVERTENCIA", "Problema cargando información del registro seleccionado", "Aceptar");
            }
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                PeriodoModel periodoModel = this.periodoModel;
                periodoModel.nombre = txtNombre.Text;
                periodoModel.fecha_inicio = txtFechaInicio.Date.ToString("yyyy-MM-dd");
                periodoModel.fecha_fin = txtFechaFin.Date.ToString("yyyy-MM-dd");
                periodoModel.estado = cmbEstado.SelectedItem.ToString();
                await periodoService.PutPeriodo(Int32.Parse(txtCodigo.Text), periodoModel);
                await DisplayAlert("CORRECTO", "Registro actualizado con éxito", "Aceptar");
                await Navigation.PushAsync(new PeriodoPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var respuesta=await DisplayAlert("ADVERTENCIA", "¿Eliminar registro?", "SI", "NO");
                if (respuesta) { 
                    await periodoService.DeletePeriodo(Int32.Parse(txtCodigo.Text));
                    await DisplayAlert("CORRECTO", "Registro eliminado con éxito", "Aceptar");
                    await Navigation.PushAsync(new PeriodoPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PeriodoPage());
        }
    }
}