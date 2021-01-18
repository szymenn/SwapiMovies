using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Castle.DynamicProxy.Internal;
using Moq;
using SwapiMovies.Core.Dto;
using SwapiMovies.Core.Entities;
using SwapiMovies.Core.Interfaces;
using SwapiMovies.Core.Services;
using Xunit;

namespace SwapiMovies.Tests.SwapiMovies.Core.Tests
{
    public class RatingServiceTests
    {
        private readonly Mock<IRatingRepository> _ratingRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private RatingService _ratingService;

        public RatingServiceTests()
        {
            _ratingRepositoryMock = new Mock<IRatingRepository>();
            _mapperMock = new Mock<IMapper>();
            
            _ratingService = new RatingService(_ratingRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void Add_ByDefault_ReturnsGuid()
        {
            _ratingRepositoryMock.Setup(e => e.Add(It.IsAny<Rating>()))
                .Returns(new Guid());

            var result = _ratingService.Add(new RatingDto());

            Assert.IsType<Guid>(result);
        }

        [Fact]
        public void Add_ByDefault_CallsRatingRepositoryOnce()
        {
            var result = _ratingService.Add(new RatingDto());
            
            _ratingRepositoryMock.Verify(e => e.Add(It.IsAny<Rating>()), Times.Once);
        }

        [Fact]
        public void Add_ByDefault_CallsMapperOnce()
        {
            var result = _ratingService.Add(new RatingDto());
            
            _mapperMock.Verify(e => e.Map<Rating>(It.IsAny<RatingDto>()), Times.Once);
        }

        [Fact]
        public void Add_WhenRatingRepositoryException_ThrowsException()
        {
            _ratingRepositoryMock.Setup(e => e.Add(It.IsAny<Rating>()))
                .Throws(new Exception());

            Assert.Throws<Exception>(() => _ratingService.Add(It.IsAny<RatingDto>()));
        }

        [Fact]
        public void Add_WhenMapperException_ThrowsException()
        {
            _mapperMock.Setup(e => e.Map<Rating>(It.IsAny<RatingDto>()))
                .Throws(new Exception());

            Assert.Throws<Exception>(() => _ratingService.Add(It.IsAny<RatingDto>()));
        }

        [Fact]
        public void GetAll_ByDefault_ReturnsIEnumerableRatingDto()
        {
            _ratingRepositoryMock.Setup(e => e.GetAll())
                .Returns(new List<Rating>());

            var result = _ratingService.GetAll();

            Assert.IsAssignableFrom<IEnumerable<RatingDto>>(result);
        }

        [Fact]
        public void GetAll_ByDefault_CallsRatingRepositoryOnce()
        {
            var result = _ratingService.GetAll();
            
            _ratingRepositoryMock.Verify(e => e.GetAll(), Times.Once);
        }

        [Fact]
        public void GetAll_ByDefault_CallsMapperOnce()
        {
            var result = _ratingService.GetAll();
            
            _mapperMock.Verify(e => e.Map<IEnumerable<RatingDto>>(It.IsAny<IEnumerable<Rating>>()), Times.Once);
        }

        [Fact]
        public void GetAll_WhenRatingRepositoryException_ThrowsException()
        {
            _ratingRepositoryMock.Setup(e => e.GetAll())
                .Throws(new Exception());

            Assert.Throws<Exception>(() => _ratingService.GetAll());
        }

        [Fact]
        public void GetAll_WhenMapperException_ThrowsException()
        {
            _mapperMock.Setup(e => e.Map<IEnumerable<RatingDto>>(It.IsAny<IEnumerable<Rating>>()))
                .Throws(new Exception());

            Assert.Throws<Exception>(() => _ratingService.GetAll());
        }
        
    }
}