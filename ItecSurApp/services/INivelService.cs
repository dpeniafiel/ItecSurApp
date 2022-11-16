using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public interface INivelService
    {
        [Get("/niveles/")]
        Task<AppResponseModel<List<NivelModel>>> GetNiveles();

        [Get("/niveles/active")]
        Task<AppResponseModel<List<NivelModel>>> GetNivelesActivos();

        [Get("/niveles/active/carrera/{carreraId}")]
        Task<AppResponseModel<List<NivelModel>>> GetNivelesActivosPorCarrera(int carreraId);

        [Get("/niveles/{id}")]
        Task<AppResponseModel<NivelModel>> GetNivel(int id);

        [Post("/niveles/")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<NivelModel>> PostNivel([Body] NivelModel nivel);

        [Put("/niveles/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<NivelModel>> PutNivel(int id, [Body] NivelModel nivel);

        [Delete("/niveles/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<NivelModel>> DeleteNivel(int id);
    }
}
