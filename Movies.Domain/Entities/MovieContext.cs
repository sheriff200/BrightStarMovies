using Microsoft.EntityFrameworkCore;
using Movies.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{

    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
