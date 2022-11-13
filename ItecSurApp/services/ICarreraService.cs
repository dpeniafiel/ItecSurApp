using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public interface ICarreraService
    {
        [Get("/carreras/")]
        Task<AppResponseModel<List<CarreraModel>>> GetCarreras();

        [Get("/carreras/{id}")]
        Task<AppResponseModel<CarreraModel>> GetCarrera(int id);

        [Post("/carreras/")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<CarreraModel>> PostCarrera([Body] CarreraModel carrera);

        [Put("/carreras/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<CarreraModel>> PutCarrera(int id, [Body] CarreraModel carrera);

        [Delete("/carreras/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<CarreraModel>> DeleteCarrera(int id);
    }
}
