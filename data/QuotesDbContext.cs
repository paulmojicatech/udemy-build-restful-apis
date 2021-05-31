using System;
using Microsoft.EntityFrameworkCore;
using UdemyBuildRestfulApis.Models;

namespace UdemyBuildRestfulApis.data
{
    public class QuotesDbContext : DbContext
    {
        public QuotesDbContext(DbContextOptions<QuotesDbContext>options) : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }
    }
}
