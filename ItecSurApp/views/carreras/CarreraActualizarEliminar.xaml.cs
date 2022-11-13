using ItecSurApp.models;
using ItecSurApp.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.carreras
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarreraActualizarEliminar : ContentPage
    {

        private CarreraModel carreraModel;
        private CarreraService carreraService;
        PeriodoService periodoService;  //propiedad
        private List<PeriodoModel> periodos;


        public  CarreraActualizarEliminar(CarreraModel carreraModel)
        {
            InitializeComponent();
            this.carreraModel = carreraModel;
            this.carreraService = new CarreraService();
            this.periodoService = new PeriodoService();
            CargarDatosIniciales();
           
         
        }

        private async void CargarDatosIniciales()
        {
            await CargarPeriodos();
            await CargarRegistroSeleccionado();
        }

        private async Task CargarPeriodos()
        {
             periodos = await periodoService.GetPeriodos();
            cmbPeriodo.ItemsSource = new ObservableCollection<PeriodoModel>(periodos);

        }

        private async Task CargarRegistroSeleccionado()
        {
            try
            {
                txtCodigo.Text = carreraModel.codigo.ToString();
                var indeceSeleccionado = periodos.FindIndex(it =>  it.codigo.Equals(carreraModel.periodo_codigo));
                cmbPeriodo.SelectedIndex = indeceSeleccionado;
                txtNombre.Text = carreraModel.nombre;   
                cmbEstado.SelectedItem = carreraModel.estado;
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
                CarreraModel carreraModel = this.carreraModel;
                PeriodoModel periodoModel = (PeriodoModel)cmbPeriodo.SelectedItem;
                carreraModel.periodo_codigo = periodoModel.codigo;
                carreraModel.nombre = txtNombre.Text;
                carreraModel.estado = cmbEstado.SelectedItem.ToString();
                await carreraService.PutCarrera(Int32.Parse(txtCodigo.Text), carreraModel);
                await DisplayAlert("CORRECTO", "Registro actualizado con éxito", "Aceptar");
                await Navigation.PushAsync(new CarreraPage());
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
                var respuesta = await DisplayAlert("ADVERTENCIA", "¿Eliminar registro?", "SI", "NO");
                if (respuesta)
                {
                    await carreraService.DeleteCarrera(Int32.Parse(txtCodigo.Text));
                    await DisplayAlert("CORRECTO", "Registro eliminado con éxito", "Aceptar");
                    await Navigation.PushAsync(new CarreraPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarreraPage());
        }

    }
}