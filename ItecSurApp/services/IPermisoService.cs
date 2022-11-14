using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public interface IPermisoService
    {
        [Get("/permisos/")]
        Task<AppResponseModel<List<PermisoModel>>> GetPermisos();

        [Get("/permisos/perfil/{id}")]
        Task<AppResponseModel<List<PermisoModel>>> GetPermisosPorPerfil(int id);

        [Get("/permisos/{id}")]
        Task<AppResponseModel<PermisoModel>> GetPermiso(int id);

        [Post("/permisos/")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<PermisoModel>> PostPermiso([Body] PermisoModel permiso);

        [Put("/permisos/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<PermisoModel>> PutPermiso(int id, [Body] PermisoModel permiso);

        [Delete("/permisos/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<PermisoModel>> DeletePermiso(int id);

        [Delete("/permisos/{opcion}/{idPerfil}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<PermisoModel>> DeletePermisoPor(string opcion, int idPerfil);
    }
}
