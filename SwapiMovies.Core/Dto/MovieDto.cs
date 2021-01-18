using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwapiMovies.Core.Dto
{
    public class MovieDto
    {
        public string Title { get; set; }
        [JsonProperty("episode_id")]
        public int EpisodeId { get; set; }    
        [JsonProperty("opening_crawl")]
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<string> Characters { get; set; }
        public IEnumerable<string> Planets { get; set; }
        public IEnumerable<string> Starships { get; set; }
        public IEnumerable<string> Vehicles { get; set; }
        public IEnumerable<string> Species { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
        public IEnumerable<int> Ratings { get; set; }

    }
}