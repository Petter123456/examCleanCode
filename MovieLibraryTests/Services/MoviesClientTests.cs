using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieLibraryTests.Services
{
    [TestClass()]
    public class MoviesClientTests
    {
        [TestMethod()]
        public void GetTop100MoviesAsync_Should_Return_descending(IFixture fixture)
        {
            //Arrange
            var sut = fixture.Create<MoviesClient>();
            //Act
            var sut = 
            //Assert
        }

    }

}
