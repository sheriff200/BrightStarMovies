using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Domain.Models;
using Movies.Infastructure.IService;

namespace Movies.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        [Route("create-movie")]
        public async Task<WebApiResponse> CreateMovie([FromBody] Movie model)
        {
            return await _movieService.CreateMovie(model);
        }

        [HttpPut]
        [Route("update-movie")]
        public async Task<WebApiResponse> UpdateMovie([FromBody] Movie model)
        {
            return await _movieService.EditMovie(model);
        }

        [HttpGet]
        [Route("get-all-movies")]
        public async Task<WebApiResponse> GetMovie()
        {
            return await _movieService.GetAllMovies();
        }

        [HttpDelete]
        [Route("delete-movie")]
        public async Task<WebApiResponse> DeleteMovie(int Id)
        {
            return await _movieService.DeleteMovie(Id);
        }
    }
}
