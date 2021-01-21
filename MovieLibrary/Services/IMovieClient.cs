using System.Collections.Generic;
using System.Threading.Tasks;
using MovieLibrary.Models;

namespace MovieLibrary.Services
{
    public interface IMovieClient
    {
        Task<IEnumerable<MovieModel>> GetTop100MoviesAsync(bool ascending);
        Task<IEnumerable<MovieModel>> GetAllAvailableMoviesAsync(bool ascending);
        Task<MovieModel> GetMovieAsync(string id);
    }
}