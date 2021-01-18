using AutoMapper;
using SwapiMovies.Core.Dto;
using SwapiMovies.Core.Entities;

namespace SwapiMovies.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RatingDto, Rating>();
            CreateMap<Rating, RatingDto>();
            
        }
    }
}