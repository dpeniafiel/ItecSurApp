using ItecSurApp.conf;
using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public class PeriodoService
    {
        IPeriodoService periodoService;
        public PeriodoService()
        {
            periodoService = RestService.For<IPeriodoService>(AppConf.BACKEND_URL);
        }

        public async Task<List<PeriodoModel>> GetPeriodos()
        {
            var appResponseModel = await periodoService.GetPeriodos();
            if (appResponseModel.error !=null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task PostPeriodo(PeriodoModel periodoModel)
        {
            var appResponseModel = await periodoService.PostPeriodo(periodoModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task PutPeriodo(int id, PeriodoModel periodoModel)
        {
            var appResponseModel = await periodoService.PutPeriodo(id, periodoModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task DeletePeriodo(int id)
        {
            var appResponseModel = await periodoService.DeletePeriodo(id);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }
    }
}
