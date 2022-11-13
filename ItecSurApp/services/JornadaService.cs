using ItecSurApp.conf;
using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public class JornadaService
    {
        IJornadaService jornadaService;
        public JornadaService()
        {
            jornadaService = RestService.For<IJornadaService>(AppConf.BACKEND_URL);
        }

        public async Task<List<JornadaModel>> GetJornadas()
        {
            var appResponseModel = await jornadaService.GetJornadas();
            if (appResponseModel.error !=null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task PostJornada(JornadaModel jornadaModel)
        {
            var appResponseModel = await jornadaService.PostJornada(jornadaModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task PutJornada(int id, JornadaModel jornadaModel)
        {
            var appResponseModel = await jornadaService.PutJornada(id, jornadaModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task DeleteJornada(int id)
        {
            var appResponseModel = await jornadaService.DeleteJornada(id);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }
    }
}
