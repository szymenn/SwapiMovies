using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using SwapiMovies.Core.Dto;
using SwapiMovies.Core.Entities;
using SwapiMovies.Core.Interfaces;

namespace SwapiMovies.Core.Services
{
    public class RatingService : IRatingService
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _repository;

        public RatingService(IRatingRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public Guid Add(RatingDto rating)
        {
            return _repository.Add(_mapper.Map<Rating>(rating));
        }

        public IEnumerable<RatingDto> GetAll()
        {
            return _mapper.Map<IEnumerable<RatingDto>>(_repository.GetAll());
        }
    }
}