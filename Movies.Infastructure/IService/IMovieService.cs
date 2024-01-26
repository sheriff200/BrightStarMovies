using Movies.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infastructure.IService
{
    public interface IMovieService
    {
        Task<WebApiResponse> CreateMovie(MovieRequest model);
        Task<WebApiResponse> EditMovie(MovieUpdateRequest model);
        Task<WebApiResponse> GetAllMovies();
        Task<WebApiResponse> DeleteMovie(int Id);

    }
}
