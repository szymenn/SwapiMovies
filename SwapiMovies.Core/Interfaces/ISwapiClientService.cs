using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SwapiMovies.Core.Dto;

namespace SwapiMovies.Core.Interfaces
{
    public interface ISwapiClientService
    {
        Task<IEnumerable<MovieDto>> GetAll();
        Task<MovieDto> GetDetails(string url);
    }
}