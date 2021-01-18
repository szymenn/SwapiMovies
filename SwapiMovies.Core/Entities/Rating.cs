using System;

namespace SwapiMovies.Core.Entities
{
    public class Rating
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public string Url { get; set; }
    }
}