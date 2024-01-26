using Movies.Domain.Entities;
using Movies.Domain.Models;
using Movies.Infastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Services
{
    public class MovieService : IMovieService
    {
        private MovieContext _context;
        public MovieService(MovieContext context)
        {
            _context = context;
        }

        public async Task<WebApiResponse> CreateMovie(Movie model)
        {
            try
            {
                _context.Add(model);
                int response = await _context.SaveChangesAsync();
                if (response > 0)
                {
                    return new WebApiResponse { ResponseCode = APiResponseCode.Successful, StatusCode = APiResponseCode.StatusOk, Message = "successful", Data = model };
                }
                else
                {
                    return new WebApiResponse { ResponseCode = APiResponseCode.Failed, StatusCode = APiResponseCode.Failed, Message = "Failed" };

                }

            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = APiResponseCode.InternalServerError, StatusCode = APiResponseCode.Failed, Message = ex.ToString() };
            }
        }

        public async Task<WebApiResponse> DeleteMovie(int Id)
        {
            try
            {
                var getmoviebyId = await GetMovieById(Id);
                var getrec = (Movie)getmoviebyId.Data;

                _context.Remove(getrec);
                int response = await _context.SaveChangesAsync();

                if (response > 0)
                {
                    return new WebApiResponse { ResponseCode = APiResponseCode.Successful, StatusCode = APiResponseCode.StatusOk, Message = "successful" };
                }
                else
                {
                    return new WebApiResponse { ResponseCode = APiResponseCode.Failed, StatusCode = APiResponseCode.Failed, Message = "Failed" };

                }

            }
            catch (Exception ex)
            {
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
                    return new WebApiResponse { ResponseCode = APiResponseCode.Successful, StatusCode = APiResponseCode.StatusOk, Message = "successful", Data = model };
                }
                else
                {
                    return new WebApiResponse { ResponseCode = APiResponseCode.Failed, StatusCode = APiResponseCode.Failed, Message = "Failed" };

                }

            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = APiResponseCode.InternalServerError, StatusCode = APiResponseCode.Failed, Message = ex.ToString() };
            }
        }

        public async Task<WebApiResponse> GetAllMovies(Movie model)
        {
            List<Movie> MovieList;
            try
            {
                MovieList = _context.Set<Movie>().ToList();
                return new WebApiResponse { ResponseCode = APiResponseCode.Successful, StatusCode = APiResponseCode.StatusOk, Message = "successful", Data = MovieList };
            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = APiResponseCode.InternalServerError, StatusCode = APiResponseCode.Failed, Message = ex.ToString() };
            }
        }

        public async Task<WebApiResponse> GetMovieById(int Id)
        {
            Movie movie;
            try
            {
                movie = await _context.FindAsync<Movie>(Id);
            }
            catch (Exception ex)
            {
                return new WebApiResponse { ResponseCode = APiResponseCode.InternalServerError, StatusCode = APiResponseCode.Failed, Message = ex.ToString() };
            }
            return new WebApiResponse { ResponseCode = APiResponseCode.Successful, StatusCode = APiResponseCode.StatusOk, Message = "successful", Data = movie };

        }
    }
}
