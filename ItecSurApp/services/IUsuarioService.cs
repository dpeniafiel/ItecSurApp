using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public interface IUsuarioService
    {
        [Get("/usuarios/")]
        Task<AppResponseModel<List<UsuarioModel>>> GetUsuarios();

        [Get("/usuarios/{id}")]
        Task<AppResponseModel<UsuarioModel>> GetUsuario(int id);

        [Get("/usuarios/{usuario}/{clave}")]
        Task<AppResponseModel<UsuarioModel>> GetUsuarioPor(string usuario, string clave);

        [Post("/usuarios/")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<UsuarioModel>> PostUsuario([Body] UsuarioModel usuario);

        [Put("/usuarios/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<UsuarioModel>> PutUsuario(int id, [Body] UsuarioModel usuario);

        [Delete("/usuarios/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<UsuarioModel>> DeleteUsuario(int id);
    }
}
