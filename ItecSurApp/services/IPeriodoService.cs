using ItecSurApp.models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItecSurApp.services
{
    public interface IPeriodoService
    {
        [Get("/periodos/")]
        Task<AppResponseModel<PeriodoModel>> GetPeriodos();

        [Get("/periodos/{id}")]
        Task<AppResponseModel<PeriodoModel>> GetPeriodo(int id);

        [Post("/periodos/")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<PeriodoModel>> PostPeriodo([Body] PeriodoModel periodo);

        [Put("/periodos/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<PeriodoModel>> PutPeriodo(int id, [Body] PeriodoModel periodo);

        [Delete("/periodos/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AppResponseModel<PeriodoModel>> DeletePeriodo(int id);
    }
}
