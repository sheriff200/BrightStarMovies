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
        Task<WebApiResponse> CreateMovie(Movie model);
        Task<WebApiResponse> EditMovie(Movie model);
        Task<WebApiResponse> GetAllMovies();
        Task<WebApiResponse> DeleteMovie(int Id);

    }
}
