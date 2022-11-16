using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public interface IInscripcionService
    {
        [Get("/inscripciones/")]
        Task<AppResponseModel<List<InscripcionModel>>> GetInscripciones();

        [Get("/inscripciones/active")]
        Task<AppResponseModel<List<InscripcionModel>>> GetInscripcionesActivas();

        [Get("/inscripciones/{id}")]
        Task<AppResponseModel<InscripcionModel>> GetInscripcion(int id);

        [Post("/inscripciones/")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<InscripcionModel>> PostInscripcion([Body] InscripcionModel inscripcion);

        [Put("/inscripciones/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<InscripcionModel>> PutInscripcion(int id, [Body] InscripcionModel inscripcion);

        [Delete("/inscripciones/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<InscripcionModel>> DeleteInscripcion(int id);
    }
}
