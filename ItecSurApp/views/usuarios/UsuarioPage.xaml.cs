using ItecSurApp.models;
using ItecSurApp.services;
using ItecSurApp.views.usuarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.usuarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioPage : ContentPage
    {
        private UsuarioService UsuarioService;
        public UsuarioPage()
        {
            InitializeComponent();
            UsuarioService = new UsuarioService();
            CargarDatos();
        }

        private async void CargarDatos()
        {
            try
            {
                var datos = await UsuarioService.GetUsuarios();
                listRegistros.ItemsSource = new ObservableCollection<UsuarioModel>(datos);
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private void listRegistros_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           // Navigation.PushAsync(new UsuarioActualizarEliminar((UsuarioModel)e.SelectedItem));
        }

        private void btnNuevo_Clicked(object sender, EventArgs e)
        {
          //  Navigation.PushAsync(new UsuarioAgregar());
        }
    }
}