using ItecSurApp.conf;
using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public class PermisoService
    {
        IPermisoService permisoService;
        public PermisoService()
        {
            permisoService = RestService.For<IPermisoService>(AppConf.BACKEND_URL);
        }

        public async Task<List<PermisoModel>> GetPermisos()
        {
            var appResponseModel = await permisoService.GetPermisos();
            if (appResponseModel.error !=null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task<List<PermisoModel>> GetPermisosPorPerfil(int perfilCodigo)
        {
            var appResponseModel = await permisoService.GetPermisosPorPerfil(perfilCodigo);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task PostPermiso(PermisoModel permisoModel)
        {
            var appResponseModel = await permisoService.PostPermiso(permisoModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task PutPermiso(int id, PermisoModel permisoModel)
        {
            var appResponseModel = await permisoService.PutPermiso(id, permisoModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task DeletePermiso(int id)
        {
            var appResponseModel = await permisoService.DeletePermiso(id);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task DeletePermisoPor(string opcion, int idPerfil)
        {
            var appResponseModel = await permisoService.DeletePermisoPor(opcion, idPerfil);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }
    }
}
