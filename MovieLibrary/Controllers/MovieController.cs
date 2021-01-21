using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models;
using MovieLibrary.Services;

namespace MovieLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieClient _movieClient;

        public MovieController(IMovieClient movieClient)
        {
            _movieClient = movieClient;
        }

        [HttpGet]
        [Route("/GetTopp100MoviesAsync")]
        public async Task<IEnumerable<MovieModel>> GetTopp100MoviesAsync(bool ascending = true)
        {
            return await _movieClient.GetTop100MoviesAsync(ascending);
        }
        
        [HttpGet]
        [Route("/GetMovieAsync")]
        public async Task<MovieModel> GetMovieAsync(string id)
        {
            return await _movieClient.GetMovieAsync(id);
        }

        [HttpGet]
        [Route("/GetAllAvailableMoviesAsync")]
        public async Task<IEnumerable<MovieModel>> GetAllAvailableMoviesAsync(bool ascending = true)
        {
            return await _movieClient.GetAllAvailableMoviesAsync(ascending);
        }
    }
}