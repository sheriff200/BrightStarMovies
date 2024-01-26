using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Core.Services;
using Movies.Domain.Models;
using Movies.Infastructure.IService;

namespace Movies.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }


        [HttpPost]
        [Route("create-genre")]
        public async Task<WebApiResponse> CreateGenre([FromBody] GenreRequest model)
        {
            return await _genreService.CreateGenre(model);
        }

        [HttpPut]
        [Route("update-genre")]
        public async Task<WebApiResponse> UpdateMovie([FromBody] Genre model)
        {
            return await _genreService.EditGenre(model);
        }

        [HttpGet]
        [Route("get-all-genres")]
        public async Task<WebApiResponse> GetMovie()
        {
            return await _genreService.GetAllGenres();
        }
    }
}
