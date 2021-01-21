using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MovieLibrary.Models;
using MovieLibraryTests1.Services;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MovieLibrary.Services.Tests
{
    [TestClass()]
    public class MoviesClientTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void GetTop100MoviesAsyncTest_should_be_list_of_movie_models( MoviesClient sut )
        {
            //act
            var actual = sut.GetTop100MoviesAsync(true).Result.ToList();
            //assert
            actual.Should().BeOfType<List<MovieModel>>(); 
        }

        [Theory]
        [AutoNSubstituteData]
        public void GetTop100MoviesAsyncTest_should_be_in_ascending_order(MoviesClient sut)
        {
            //act
            var actual = sut.GetTop100MoviesAsync(true).Result.ToList();
            //assert
            actual.Should().BeInAscendingOrder( x => x.Rated); 
        }

        [Theory]
        [AutoNSubstituteData]
        public void GetTop100MoviesAsyncTest_should_be_in_decending_order(MoviesClient sut)
        {
            //act
            var actual = sut.GetTop100MoviesAsync(false).Result.ToList();
            //assert
            actual.Should().BeInDescendingOrder(x => x.Rated);
        }

        [Theory]
        [AutoNSubstituteData]
        public async void GetAllAvailableMoviesAsync_should_be_list_of_movie_models(MoviesClient sut)
        {
            //act
            var actual = sut.GetAllAvailableMoviesAsync(true);
            //assert
            actual.Result.ToList().Should().BeOfType<List<MovieModel>>();
        }

        [Theory]
        [AutoNSubstituteData]
        public void GetAllAvailableMoviesAsync_should_be_in_ascending_order(MoviesClient sut)
        {
            //act
            var actual = sut.GetAllAvailableMoviesAsync(true).Result.ToList();
            //assert
            actual.Should().BeInAscendingOrder(x => x.Title);
        }

        [Theory]
        [AutoNSubstituteData]
        public void GetAllAvailableMoviesAsync_should_be_in_descending_order(MoviesClient sut)
        {
            //act
            var actual = sut.GetAllAvailableMoviesAsync(false).Result.ToList();
            //assert
            actual.Should().BeInDescendingOrder(x => x.Title);
        }


        [Theory]
        [AutoNSubstituteData]
        public void GetMovieAsyncTest(MoviesClient sut)
        {
            //act
            var actual = sut.GetMovieAsync("tt0111161").Result;
            //Assert
            actual.Should().BeOfType<MovieModel>();
        }
    }
}