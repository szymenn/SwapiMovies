using System;
using System.ComponentModel.DataAnnotations;

namespace SwapiMovies.Core.Dto
{
    public class RatingDto
    {
        public Guid? Id { get; set; }
        
        [Required(ErrorMessage = "Value is required")]
        [Range(0, 10, ErrorMessage = "Rating value for {0} must be between {1} and {2}")]
        public int? Value { get; set; }
        
        public string Url { get; set; }
    }
}