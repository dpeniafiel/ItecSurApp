using ItecSurApp.conf;
using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public class NivelService
    {
        INivelService nivelService;
        public NivelService()
        {
            nivelService = RestService.For<INivelService>(AppConf.BACKEND_URL);
        }

        public async Task<List<NivelModel>> GetNiveles()
        {
            var appResponseModel = await nivelService.GetNiveles();
            if (appResponseModel.error !=null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task<List<NivelModel>> GetNivelesActivos()
        {
            var appResponseModel = await nivelService.GetNivelesActivos();
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task<List<NivelModel>> GetNivelesActivosPorCarrera(int carreraId)
        {
            var appResponseModel = await nivelService.GetNivelesActivosPorCarrera(carreraId);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task PostNivel(NivelModel nivelModel)
        {
            var appResponseModel = await nivelService.PostNivel(nivelModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task PutNivel(int id, NivelModel nivelModel)
        {
            var appResponseModel = await nivelService.PutNivel(id, nivelModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task DeleteNivel(int id)
        {
            var appResponseModel = await nivelService.DeleteNivel(id);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }
    }
}
