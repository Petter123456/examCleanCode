using System.Collections.Generic;
using System.Net.Http;
using AutoFixture;
using Microsoft.Extensions.Configuration;
using MovieLibrary.Models;
using MovieLibrary.Services;

namespace MovieLibraryTests1.Services
{
    public class MoviesClientCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            IConfiguration configRoot = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "BugClientUrl", "http://localhost:80/bugsapi/" },
                    { "Loggers:0", "1" },
                    { "Loggers:1", "2" },
                    { "Loggers:2", "3" }
                })
                .Build();

            var movie = fixture.Build<MovieModel>().CreateMany();
            var movieClient = new MoviesClient(configRoot, new HttpClient());


            fixture.Register(() => movie);
            fixture.Register(() => configRoot);
            fixture.Register(() => movieClient);

        }
    }
}