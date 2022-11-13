using ItecSurApp.models;
using ItecSurApp.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.carreras
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarreraAgregar : ContentPage
    {
        CarreraService carreraService;
        PeriodoService periodoService;  //propiedad

        public CarreraAgregar()
        {
            InitializeComponent();
            carreraService = new CarreraService();
            periodoService = new PeriodoService();
            CargarPeriodos();

        }

        private async void CargarPeriodos()
        {
            var periodos = await periodoService.GetPeriodos();
            cmbPeriodo.ItemsSource = new ObservableCollection<PeriodoModel>(periodos);

        }


            private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                CarreraModel carreraModel = new CarreraModel();      
                PeriodoModel periodoModel = (PeriodoModel)cmbPeriodo.SelectedItem;
                carreraModel.periodo_codigo = periodoModel.codigo;
                carreraModel.nombre = txtNombre.Text;
                carreraModel.estado = "ACTIVO";
                await carreraService.PostCarrera(carreraModel);
                await DisplayAlert("CORRECTO", "Registro ingresado con éxito", "Aceptar");
                await Navigation.PushAsync(new CarreraPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CarreraPage());
        }

    }
}