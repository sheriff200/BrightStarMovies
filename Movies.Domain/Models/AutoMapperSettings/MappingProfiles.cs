using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Models.AutoMapperSettings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<MovieRequest, Movie>().ReverseMap();
            CreateMap<MovieUpdateRequest, Movie>().ReverseMap();
            CreateMap<GenreRequest, Genre>().ReverseMap();
        }
    }
   
}
