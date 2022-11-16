using ItecSurApp.conf;
using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public class CarreraService
    {
        ICarreraService carreraService;
        public CarreraService()
        {
            carreraService = RestService.For<ICarreraService>(AppConf.BACKEND_URL);
        }

        public async Task<List<CarreraModel>> GetCarreras()
        {
            var appResponseModel = await carreraService.GetCarreras();
            if (appResponseModel.error !=null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task<List<CarreraModel>> GetCarrerasActivas()
        {
            var appResponseModel = await carreraService.GetCarrerasActivas();
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task<List<CarreraModel>> GetCarrerasActivasPorPeriodo(int periodo)
        {
            var appResponseModel = await carreraService.GetCarrerasActivasPorPeriodo(periodo);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task PostCarrera(CarreraModel carreraModel)
        {
            var appResponseModel = await carreraService.PostCarrera(carreraModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task PutCarrera(int id, CarreraModel carreraModel)
        {
            var appResponseModel = await carreraService.PutCarrera(id, carreraModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task DeleteCarrera(int id)
        {
            var appResponseModel = await carreraService.DeleteCarrera(id);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }
    }
}
