using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwapiMovies.Core.Dto
{
    public class MoviesResponseDto
    {
        public int Count { get; set; }
        public List<MovieDto> Results { get; set; }
    }
}