using ItecSurApp.models;
using ItecSurApp.services;
using ItecSurApp.views.inicio;
using ItecSurApp.views.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ItecSurApp.views.permisos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PermisoPage : ContentPage
    {
        private PerfilService perfilService;
        private PermisoService permisoService;
        public PermisoPage()
        {
            InitializeComponent();
            perfilService = new PerfilService();
            permisoService = new PermisoService();
            CargarPerfiles();
        }

        private async void CargarPerfiles()
        {
            var perfiles = await perfilService.GetPerfiles();
            cmbPerfil.ItemsSource = new ObservableCollection<PerfilModel>(perfiles);

        }


        private async void CargarPermisosDePerfil(int perfilCodigo)
        {
            var permisosDePerfil = await permisoService.GetPermisosPorPerfil(perfilCodigo);
            chkPeriodo.IsChecked = false;
            chkCarrera.IsChecked = false;
            chkNivel.IsChecked = false;
            chkJornada.IsChecked = false;
            chkInscripcion.IsChecked = false;
            chkPerfil.IsChecked = false;
            chkUsuario.IsChecked = false;
            chkPermiso.IsChecked = false;
            chkInforme1.IsChecked = false;
            ActivarCheck(chkPeriodo, "PERIODO", permisosDePerfil);
            ActivarCheck(chkCarrera, "CARRERA", permisosDePerfil);
            ActivarCheck(chkNivel, "NIVEL", permisosDePerfil);
            ActivarCheck(chkJornada, "JORNADA", permisosDePerfil);
            ActivarCheck(chkInscripcion, "INSCRIPCION", permisosDePerfil);
            ActivarCheck(chkPerfil, "PERFIL", permisosDePerfil);
            ActivarCheck(chkUsuario, "USUARIO", permisosDePerfil);
            ActivarCheck(chkPermiso, "PERMISO", permisosDePerfil);
            ActivarCheck(chkInforme1, "INFORME1", permisosDePerfil);


        }

        private void ActivarCheck(CheckBox check, string permiso, List<PermisoModel> permisosDePerfil)
        {
            int indice = permisosDePerfil.FindIndex(it => it.opcion_codigo.Equals(permiso));
            if (indice >= 0)
            {
                check.IsChecked = true;
            }
        }

        private void cmbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerfilModel perfilSeleccionado = (PerfilModel)cmbPerfil.SelectedItem;
            CargarPermisosDePerfil(perfilSeleccionado.codigo);
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                PerfilModel perfilSeleccionado = (PerfilModel)cmbPerfil.SelectedItem;
                await GuardarPermiso("PERIODO", chkPeriodo.IsChecked ,perfilSeleccionado);
                await GuardarPermiso("CARRERA", chkCarrera.IsChecked, perfilSeleccionado);
                await GuardarPermiso("NIVEL", chkNivel.IsChecked, perfilSeleccionado);
                await GuardarPermiso("JORNADA", chkJornada.IsChecked, perfilSeleccionado);
                await GuardarPermiso("INSCRIPCION", chkInscripcion.IsChecked, perfilSeleccionado);
                await GuardarPermiso("PERFIL", chkPerfil.IsChecked, perfilSeleccionado);
                await GuardarPermiso("USUARIO", chkUsuario.IsChecked, perfilSeleccionado);
                await GuardarPermiso("PERMISO", chkPermiso.IsChecked, perfilSeleccionado);
                await GuardarPermiso("INFORME1", chkInforme1.IsChecked, perfilSeleccionado);
                await DisplayAlert("CORRECTO", "Cambios aplicados con éxito", "Aceptar");
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", ex.Message, "Aceptar");
            }
        }

        private async Task GuardarPermiso(string nombre, bool quitarPoner, PerfilModel perfilSeleccionado)
        {
            if (quitarPoner) {
                await permisoService.DeletePermisoPor(nombre, perfilSeleccionado.codigo);
                await permisoService.PostPermiso(new PermisoModel { estado = "ACTIVO", nombre = nombre, opcion_codigo = nombre, perfil_codigo = perfilSeleccionado.codigo });
            }
            else
            {
                await permisoService.DeletePermisoPor(nombre, perfilSeleccionado.codigo);
            }
        }

    }
}