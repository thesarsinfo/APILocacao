using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILocacao.Controllers;
using APILocacao.DTO;
using APILocacao.Models;
using APILocacao.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace App.Xunit
{
    public class RentMovieControllerTests
    {
        private readonly IRentMovieRepository _rentMovieRepository;       

        [Fact]
        public async Task AddRent_WhereClientIdNoExistsInDataBase_ReturnNotFound()
        {
            //Arrange          
            var rentMovieRepositoryStub = new Mock<IRentMovieRepository>();            
            rentMovieRepositoryStub.Setup(repo => repo.GetClientAsync(It.IsAny<ulong>()))
            .ReturnsAsync((Client) null);
            var controller = new RentMovieController(rentMovieRepositoryStub.Object);
            
            //Act
            RentMovieDTO rentMovieDTO = new RentMovieDTO()
            {         
            ClientId = 1234567890,
            MovieId = 1,
            FinalDeliveryDate = new DateTime(year:2022,month:7,day:10,hour:0,minute:0,second:0),
            ReturnMovie = false,
            TotalRent = 3
            };           
             var result =await controller.AddRent(rentMovieDTO);           
            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }        
    }
}

