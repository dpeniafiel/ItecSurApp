using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public interface IJornadaService
    {
        [Get("/jornadas/")]
        Task<AppResponseModel<List<JornadaModel>>> GetJornadas();

        [Get("/jornadas/{id}")]
        Task<AppResponseModel<JornadaModel>> GetJornada(int id);

        [Post("/jornadas/")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<JornadaModel>> PostJornada([Body] JornadaModel periodo);

        [Put("/jornadas/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<JornadaModel>> PutJornada(int id, [Body] JornadaModel periodo);

        [Delete("/jornadas/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<JornadaModel>> DeleteJornada(int id);
    }
}
