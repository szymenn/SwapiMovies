using System;
using System.Collections.Generic;
using System.Linq;
using SwapiMovies.Core.Entities;
using SwapiMovies.Core.Interfaces;
using SwapiMovies.Infrastructure.Data;

namespace SwapiMovies.Infrastructure.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _context;

        public RatingRepository(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Rating> GetAll()
        {
            return _context.Ratings;
        }

        public Guid Add(Rating rating)
        {
            var id = _context.Ratings.Add(rating).Entity.Id;
            _context.SaveChanges();

            return id;
        }

        public IEnumerable<int> GetRatingsByUrl(string url)
        {
            return _context.Ratings.Where(rating => rating.Url == url).Select(rating => rating.Value);
        }
    }
}