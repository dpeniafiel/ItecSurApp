using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public interface IPerfilService
    {
        [Get("/perfiles/")]
        Task<AppResponseModel<List<PerfilModel>>> GetPerfiles();

        [Get("/perfiles/{id}")]
        Task<AppResponseModel<PerfilModel>> GetPerfil(int id);

        [Post("/perfiles/")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<PerfilModel>> PostPerfil([Body] PerfilModel perfil);

        [Put("/perfiles/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<PerfilModel>> PutPerfil(int id, [Body] PerfilModel perfil);

        [Delete("/perfiles/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<PerfilModel>> DeletePerfil(int id);
    }
}
