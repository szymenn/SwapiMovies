using System;
using System.Collections;
using System.Collections.Generic;
using SwapiMovies.Core.Dto;
using SwapiMovies.Core.Entities;

namespace SwapiMovies.Core.Interfaces
{
    public interface IRatingService
    {
        Guid Add(RatingDto rating);
        IEnumerable<RatingDto> GetAll();
    }
}