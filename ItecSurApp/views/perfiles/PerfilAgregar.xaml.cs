using ItecSurApp.models;
using ItecSurApp.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.perfiles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilAgregar : ContentPage
    {
        PerfilService perfilService;
        public PerfilAgregar()
        {
            InitializeComponent();
            perfilService = new PerfilService();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                PerfilModel perfilModel = new PerfilModel();
                perfilModel.nombre = txtNombre.Text;       
                perfilModel.estado = "ACTIVO";
                await perfilService.PostPerfil(perfilModel);
                await DisplayAlert("CORRECTO", "Registro ingresado con éxito", "Aceptar");
                await Navigation.PushAsync(new PerfilPage());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PerfilPage());
        }
    }
}