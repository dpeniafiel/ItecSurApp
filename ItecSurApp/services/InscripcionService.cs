using ItecSurApp.conf;
using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public class InscripcionService
    {
        IInscripcionService inscripcionService;
        public InscripcionService()
        {
            inscripcionService = RestService.For<IInscripcionService>(AppConf.BACKEND_URL);
        }

        public async Task<List<InscripcionModel>> GetInscripciones()
        {
            var appResponseModel = await inscripcionService.GetInscripciones();
            if (appResponseModel.error !=null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task<List<InscripcionModel>> GetInscripcionesActivos()
        {
            var appResponseModel = await inscripcionService.GetInscripcionesActivas();
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
            return appResponseModel.data;
        }

        public async Task PostInscripcion(InscripcionModel inscripcionModel)
        {
            var appResponseModel = await inscripcionService.PostInscripcion(inscripcionModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task PutInscripcion(int id, InscripcionModel inscripcionModel)
        {
            var appResponseModel = await inscripcionService.PutInscripcion(id, inscripcionModel);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }

        public async Task DeleteInscripcion(int id)
        {
            var appResponseModel = await inscripcionService.DeleteInscripcion(id);
            if (appResponseModel.error != null)
            {
                throw new Exception(appResponseModel.error);
            }
        }
    }
}
