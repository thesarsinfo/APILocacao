
using APILocacao.Models;
using APILocacao.Controllers;
using APILocacao.Repository.Interfaces;
using AutoMapper;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace App.Xunit
{
    public class MovieUnitTestController
    {

        private readonly IMapper _mapper;
        private readonly IMovieRepository _repository;


        //Testes
        [Fact]
        public async void GetMoviesById_WhenMovieDoesNotExist_ReturnNotFound() // esperando o retorno com Id inválido
        {
            var movieRepositoryStub = new Mock<IMovieRepository>();
            movieRepositoryStub.Setup(repo => repo.GetByIdMovieAsync(It.IsAny<int>())).ReturnsAsync((Movie)null);
            var mapperStub = new Mock<IMapper>();
            var controller = new MoviesController(movieRepositoryStub.Object, mapperStub.Object);

            // Given
            //  var controller = new MoviesController(_repository, _mapper);
            // When
            var result = await controller.GetById(20);
            // Then
            // Assert.IsType<List<Movie>>(movie);
            Assert.IsType<NotFoundObjectResult>(result);
        }

    }

}