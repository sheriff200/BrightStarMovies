using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Domain.Models;
using Movies.Domain.Serilog;
using Movies.Infastructure.IService;
using Newtonsoft.Json;

namespace Movies.Core.Services
{
    public class MovieService : IMovieService
    {
        private MovieContext _context;
        private readonly SeriLogger _seriLogger;
        private readonly string directory = "MovieService";

        public MovieService(MovieContext context, SeriLogger seriLogger)
        {
            _context = context;
            _seriLogger = seriLogger;
        }

        public async Task<WebApiResponse> CreateMovie(Movie model)
        {
            try
            {
                _context.Add(model);
                int response = await _context.SaveChangesAsync();
                if (response > 0)
                {
                    _seriLogger.LogRequest($"{"CreateMovie -- Movie was successfully created"}{"|"}{JsonConvert.SerializeObject(model)}{"|"}{DateTime.UtcNow}", false, directory);
                    return new WebApiResponse { ResponseCode = APiResponseCode.Successful, StatusCode = APiResponseCode.StatusOk, Message = "successful", Data = model };
                }
                else
                {
                    _seriLogger.LogRequest($"{"CreateMovie -- Unable to create movie"}{"|"}{JsonConvert.SerializeObject(model)}{"|"}{DateTime.UtcNow}", false, directory);
                    return new WebApiResponse { ResponseCode = APiResponseCode.Failed, StatusCode = APiResponseCode.Failed, Message = "Failed" };

                }

            }
            catch (Exception ex)
            {
                _seriLogger.LogRequest($"{"CreateMovie -- Internal server error occurred" + ex.ToString()}{"|"}{"|"}{DateTime.UtcNow}", false, directory);

                return new WebApiResponse { ResponseCode = APiResponseCode.InternalServerError, StatusCode = APiResponseCode.Failed, Message = ex.ToString() };
            }
        }

        public async Task<WebApiResponse> DeleteMovie(int Id)
        {
            try
            {
                var getmoviebyId = await GetMovieById(Id);

                var getgenrebyId = await GetGenreById(getmoviebyId.GenreId);
                _context.Remove(getmoviebyId);
                _context.Remove(getgenrebyId);
                int response = await _context.SaveChangesAsync();

                if (response > 0)
                {
                    _seriLogger.LogRequest($"{"DeleteMovie -- Movie was successfully deleted"}{" ID =>"}{Id}{"|"}{DateTime.UtcNow}", false, directory);
                    return new WebApiResponse { ResponseCode = APiResponseCode.Successful, StatusCode = APiResponseCode.StatusOk, Message = "successful" };
                }
                else
                {
                    _seriLogger.LogRequest($"{"DeleteMovie -- unable to delete movie with the Id "+Id}{"|"}{DateTime.UtcNow}", false, directory);

                    return new WebApiResponse { ResponseCode = APiResponseCode.Failed, StatusCode = APiResponseCode.Failed, Message = "Failed" };
                }

            }
            catch (Exception ex)
            {
                _seriLogger.LogRequest($"{"DeleteMovie -- Internal server error occurred " + ex.ToString()}{"|"}{DateTime.UtcNow}", false, directory);

                return new WebApiResponse { ResponseCode = APiResponseCode.InternalServerError, StatusCode = APiResponseCode.Failed, Message = ex.ToString() };
            }

        }

        public async Task<WebApiResponse> EditMovie(Movie model)
        {
            try
            {
                _context.Update(model);
                int response = await _context.SaveChangesAsync();
                if (response > 0)
                {
                    _seriLogger.LogRequest($"{"EditMovie -- Movie with the Id " + model.Id + " was successfully updated"}{"|"}{DateTime.UtcNow}", false, directory);
                    return new WebApiResponse { ResponseCode = APiResponseCode.Successful, StatusCode = APiResponseCode.StatusOk, Message = "successful", Data = model };
                }
                else
                {
                    _seriLogger.LogRequest($"{"EditMovie -- Unable to update movie with the Id " + model.Id}{"|"}{DateTime.UtcNow}", false, directory);

                    return new WebApiResponse { ResponseCode = APiResponseCode.Failed, StatusCode = APiResponseCode.Failed, Message = "Failed" };
                }

            }
            catch (Exception ex)
            {
                _seriLogger.LogRequest($"{"EditMovie -- Internal server error occurred " + ex.ToString()}{"|"}{DateTime.UtcNow}", false, directory);
                return new WebApiResponse { ResponseCode = APiResponseCode.InternalServerError, StatusCode = APiResponseCode.Failed, Message = ex.ToString() };
            }
        }

        public async Task<WebApiResponse> GetAllMovies()
        {
            List<Movie> MovieList;
            try
            {
                MovieList = _context.Set<Movie>().ToList();
                return new WebApiResponse { ResponseCode = APiResponseCode.Successful, StatusCode = APiResponseCode.StatusOk, Message = "successful", Data = MovieList };
            }
            catch (Exception ex)
            {
                _seriLogger.LogRequest($"{"GetAllMovies -- Internal server error occurred " + ex.ToString()}{"|"}{DateTime.UtcNow}", false, directory);
                return new WebApiResponse { ResponseCode = APiResponseCode.InternalServerError, StatusCode = APiResponseCode.Failed, Message = ex.ToString() };
            }
        }

        public async Task<Movie> GetMovieById(int Id)
        {
            Movie movie;
            try
            {
                movie = await _context.FindAsync<Movie>(Id);
            }
            catch (Exception ex)
            {
                _seriLogger.LogRequest($"{"GetMovieById -- Internal server error occurred " + ex.ToString()}{"|"}{DateTime.UtcNow}", false, directory);
                return null;
            }
            return movie;

        }

        public async Task<Genre> GetGenreById(long Id)
        {
            Genre genre;
            try
            {
                genre = await _context.Genres.Where(x => x.Id == Id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _seriLogger.LogRequest($"{"GetGenreById -- Internal server error occurred " + ex.ToString()}{"|"}{DateTime.UtcNow}", false, directory);
                return null;
            }
            return genre;
        }


    }
}
