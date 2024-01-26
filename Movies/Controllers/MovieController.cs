using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Domain.Models;

namespace Movies.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpPost]
        [Route("create-movie")]
        public IActionResult CreateMovie([FromBody] Movie model)
        {

        }
    }
}
