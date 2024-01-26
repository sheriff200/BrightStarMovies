using Movies.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infastructure.IService
{
    public interface IGenreService
    {
        Task<WebApiResponse> CreateGenre(Genre model);
        Task<WebApiResponse> EditGenre(Genre model);
    }
}
