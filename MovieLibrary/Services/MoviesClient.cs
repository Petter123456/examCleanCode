using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MovieLibrary.Models;
using Newtonsoft.Json;

namespace MovieLibrary.Services
{
    public class MoviesClient : IMovieClient
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient = new HttpClient();
        private List<MovieModel> movies;

        public MoviesClient(IConfiguration config, HttpClient httpClient)
        {
            _config = config;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MovieModel>> GetTop100MoviesAsync(bool ascending)
        {
            try
            {
                movies = new List<MovieModel>();
                var task = _httpClient.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json")
                    .ContinueWith((taskWithResponse) =>
                    {
                        var response = taskWithResponse.Result;
                        var jsonString = response.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        movies = JsonConvert.DeserializeObject<List<MovieModel>>(jsonString.Result);
                    });
                task.Wait();

                if (!ascending)
                {
                    return movies.OrderByDescending(movie => movie.Rated);
                }

                return movies.OrderBy(movie => movie.Rated);
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException($"{e}");
            }
        }

        public async Task<IEnumerable<MovieModel>> GetAllAvailableMoviesAsync(bool ascending)
        {
            try
            {
                var additionalMovies = new List<MovieModel>();
                var task = _httpClient.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json")
                    .ContinueWith((taskWithResponse) =>
                    {
                        var response = taskWithResponse.Result;
                        var jsonString = response.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        additionalMovies = JsonConvert.DeserializeObject<List<MovieModel>>(jsonString.Result);
                    });
                task.Wait();

               await GetTop100MoviesAsync(ascending);

                var newMoviesToAdd = additionalMovies
                    .Where(x => this.movies
                        .Any(y => !y.Title
                            .Equals(x.Title))).ToList();

                foreach (var movie in newMoviesToAdd)
                {
                    this.movies.Add(movie);
                }

                if (!ascending)
                {
                    return this.movies.OrderByDescending(movie => movie.Title);
                }

                return this.movies.OrderBy(movie => movie.Title);
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException($"{e}");
            }
        }

        public async Task<MovieModel> GetMovieAsync(string id)
        {
            try
            {
                movies = new List<MovieModel>();
                var task = _httpClient.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json")
                    .ContinueWith((taskWithResponse) =>
                    {
                        var response = taskWithResponse.Result;
                        var jsonString = response.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        movies = JsonConvert.DeserializeObject<List<MovieModel>>(jsonString.Result);
                    });
                task.Wait();

                var movie = movies.SingleOrDefault(movie => movie.Id.Equals(id));

                return movie;
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException($"{e}");
            }
        }
    }
}
