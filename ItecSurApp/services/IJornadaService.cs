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
        [Get("/periodos/")]
        Task<AppResponseModel<List<JornadaModel>>> GetJornadas();

        [Get("/periodos/{id}")]
        Task<AppResponseModel<JornadaModel>> GetJornada(int id);

        [Post("/periodos/")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<JornadaModel>> PostJornada([Body] JornadaModel periodo);

        [Put("/periodos/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<JornadaModel>> PutJornada(int id, [Body] JornadaModel periodo);

        [Delete("/periodos/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<JornadaModel>> DeleteJornada(int id);
    }
}
