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

namespace ItecSurApp.views.nivel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NivelAgregar : ContentPage
    {

        NivelService nivelService;
        CarreraService carreraService;  //propiedad
        public NivelAgregar()
        {
            InitializeComponent();
            nivelService = new NivelService();
            carreraService = new CarreraService();
            CargarCarreras();
        }

        private async void CargarCarreras()
        {
            var carreras = await carreraService.GetCarreras();
            cmbCarrera.ItemsSource = new ObservableCollection<CarreraModel>(carreras);

        }


        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                NivelModel nivelModel = new NivelModel();
                CarreraModel carreraModel = (CarreraModel)cmbCarrera.SelectedItem;
                nivelModel.carrera_codigo = carreraModel.codigo;
                nivelModel.nombre = txtNombre.Text;
                nivelModel.estado = "ACTIVO";
                await nivelService.PostNivel(nivelModel);
                await DisplayAlert("CORRECTO", "Registro ingresado con éxito", "Aceptar");
                await Navigation.PushAsync(new NivelPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NivelPage());
        }

    }
}