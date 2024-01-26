using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Domain.Models;
using Movies.Domain.Serilog;
using Movies.Infastructure.IService;
using Newtonsoft.Json;
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
        private readonly SeriLogger _seriLogger;
        private readonly string directory = "GenreService";
        private readonly IMapper _mapper;
        public GenreService(MovieContext context, SeriLogger seriLogger, IMapper mapper)
        {
            _context = context;
            _seriLogger = seriLogger;
            _mapper = mapper;
        }
        
        public async Task<WebApiResponse> CreateGenre(GenreRequest model)
        {
            try
            {
                var mapper = _mapper.Map<Genre>(model);

                _context.Add(mapper);
                int response = await _context.SaveChangesAsync();
                if (response > 0)
                {
                    _seriLogger.LogRequest($"{"CreateGenre -- Genre was successfully created"}{"|"}{JsonConvert.SerializeObject(mapper)}{"|"}{DateTime.UtcNow}", false, directory);
                    return new WebApiResponse { ResponseCode = APiResponseCode.Successful, StatusCode = APiResponseCode.StatusOk, Message = "successful", Data = model };
                }
                else
                {
                    _seriLogger.LogRequest($"{"CreateGenre -- Unable to create genre"}{"|"}{JsonConvert.SerializeObject(mapper)}{"|"}{DateTime.UtcNow}", false, directory);
                    return new WebApiResponse { ResponseCode = APiResponseCode.Failed, StatusCode = APiResponseCode.Failed, Message = "Failed" };

                }

            }
            catch (Exception ex)
            {
                _seriLogger.LogRequest($"{"CreateGenre -- Internal server error occurred" + ex.ToString()}{"|"}{"|"}{DateTime.UtcNow}", false, directory);
                return new WebApiResponse { ResponseCode = APiResponseCode.InternalServerError, StatusCode = APiResponseCode.Failed, Message = ex.ToString() };
            }
        }

        public async Task<WebApiResponse> GetAllGenres()
        {
            List<Genre> GenreList;
            try
            {
                GenreList = _context.Set<Genre>().ToList();
                return new WebApiResponse { ResponseCode = APiResponseCode.Successful, StatusCode = APiResponseCode.StatusOk, Message = "successful", Data = GenreList };
            }
            catch (Exception ex)
            {
                _seriLogger.LogRequest($"{"GetAllGenres -- Internal server error occurred " + ex.ToString()}{"|"}{DateTime.UtcNow}", false, directory);
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
                    _seriLogger.LogRequest($"{"EditGenre -- genre with the Id " + model.Id + " was successfully updated"}{"|"}{DateTime.UtcNow}", false, directory);

                    return new WebApiResponse { ResponseCode = APiResponseCode.Successful, StatusCode = APiResponseCode.StatusOk, Message = "successful", Data = model };
                }
                else
                {
                    _seriLogger.LogRequest($"{"EditGenre -- Unable to update genre with the Id " + model.Id}{"|"}{DateTime.UtcNow}", false, directory);

                    return new WebApiResponse { ResponseCode = APiResponseCode.Failed, StatusCode = APiResponseCode.Failed, Message = "Failed" };

                }

            }
            catch (Exception ex)
            {
                _seriLogger.LogRequest($"{"EditGenre -- Internal server error occurred " + ex.ToString()}{"|"}{DateTime.UtcNow}", false, directory);
                return new WebApiResponse { ResponseCode = APiResponseCode.InternalServerError, StatusCode = APiResponseCode.Failed, Message = ex.ToString() };
            }
        }
    }
}
