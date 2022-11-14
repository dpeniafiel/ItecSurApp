using ItecSurApp.conf;
using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public class UsuarioService
    {
        IUsuarioService usuarioService;
        public UsuarioService()
        {
            usuarioService = RestService.For<IUsuarioService>(AppConf.BACKEND_URL);
        }

        public async Task<List<UsuarioModel>> GetUsuarios()
        {
            var appResponseModel = await usuarioService.GetUsuarios();
            if (appResponseModel.error !=null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task<UsuarioModel> GetUsuarioPor(String usuario, String clave)
        {
            var appResponseModel = await usuarioService.GetUsuarioPor(usuario, clave);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task PostUsuario(UsuarioModel usuarioModel)
        {
            var appResponseModel = await usuarioService.PostUsuario(usuarioModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task PutUsuario(int id, UsuarioModel usuarioModel)
        {
            var appResponseModel = await usuarioService.PutUsuario(id, usuarioModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task DeleteUsuario(int id)
        {
            var appResponseModel = await usuarioService.DeleteUsuario(id);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }
    }
}
