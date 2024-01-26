using Microsoft.EntityFrameworkCore;
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
    public class GenreService : IGenreService
    {
        private MovieContext _context;
        public GenreService(MovieContext context)
        {
            _context = context;
        }
        
        public async Task<WebApiResponse> CreateGenre(Genre model)
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

        public async Task<WebApiResponse> EditGenre(Genre model)
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
    }
}
