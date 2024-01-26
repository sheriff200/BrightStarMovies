using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Models
{
    public class Movie
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleasedDate { get; set; }
        public MovieRating Rating { get; set; }
        public decimal TicketPrice { get; set; }
        public string Country { get; set; }
        public long GenreId { get; set; }
        public string Photo { get; set; }
    }

    public class MovieRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleasedDate { get; set; }
        public MovieRating Rating { get; set; }
        public decimal TicketPrice { get; set; }
        public string Country { get; set; }
        public long GenreId { get; set; }
        public IFormFile Photo { get; set; }
    }

    public class MovieUpdateRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleasedDate { get; set; }
        public MovieRating Rating { get; set; }
        public decimal TicketPrice { get; set; }
        public string Country { get; set; }
        public long GenreId { get; set; }
        public IFormFile Photo { get; set; }
    }

    public enum MovieRating
    {
        first = 1,
        second = 2,
        third = 3,
        forth = 4,
        fivth = 5
    }
}
