using ItecSurApp.conf;
using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public class PerfilService
    {
        IPerfilService perfilService;
        public PerfilService()
        {
            perfilService = RestService.For<IPerfilService>(AppConf.BACKEND_URL);
        }

        public async Task<PerfilModel> GetPerfilPor(int perfilCodigo)
        {
            var appResponseModel = await perfilService.GetPerfil(perfilCodigo);
            if (appResponseModel.error !=null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task<List<PerfilModel>> GetPerfiles()
        {
            var appResponseModel = await perfilService.GetPerfiles();
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task PostPerfil(PerfilModel perfilModel)
        {
            var appResponseModel = await perfilService.PostPerfil(perfilModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task PutPerfil(int id, PerfilModel perfilModel)
        {
            var appResponseModel = await perfilService.PutPerfil(id, perfilModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task DeletePerfil(int id)
        {
            var appResponseModel = await perfilService.DeletePerfil(id);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }
    }
}
