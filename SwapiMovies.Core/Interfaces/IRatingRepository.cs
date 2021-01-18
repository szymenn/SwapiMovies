using System;
using System.Collections;
using System.Collections.Generic;
using SwapiMovies.Core.Entities;

namespace SwapiMovies.Core.Interfaces
{
    public interface IRatingRepository
    {
        IEnumerable<Rating> GetAll();
        Guid Add(Rating rating);
        IEnumerable<int> GetRatingsByUrl(string url);
    }
}