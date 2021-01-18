using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SwapiMovies.Core.Dto;
using SwapiMovies.Core.Interfaces;

namespace SwapiMovies.Infrastructure.Services 
{
    public class SwapiClientService : ISwapiClientService 
    {
        private readonly HttpClient _client;
        private readonly IRatingRepository _repository;

        public SwapiClientService(HttpClient client, IRatingRepository repository)
        {
            _client = client;
            _repository = repository;
        }


        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            var response = await _client.GetAsync("https://swapi.dev/api/films/");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<MoviesResponseDto>(responseString).Results;
        }

        public async Task<MovieDto> GetDetails(string url)
        {
            var movie = await GetDetailsRequest(url);

            movie.Ratings = _repository.GetRatingsByUrl(url);
            return movie;
        }

        private async Task<MovieDto> GetDetailsRequest(string url)
        {
            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<MovieDto>(responseString);
        }
     }

}
