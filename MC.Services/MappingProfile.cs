using AutoMapper;
using MC.Domain;
using MC.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateDirectorDto, Director>();
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<CreateActorDto, Actor>();
            CreateMap<CreateMoviesActorsDto, MoviesActors>();
        }
    }
}
