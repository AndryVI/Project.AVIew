using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.AVIew.EF.Entities.User;
using Project.AVIew.EF.Entities.Weather;
using System.Linq;


namespace Project.AVIew.EF
{
    public class AVIewDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public AVIewDbContext()
        { }
        public AVIewDbContext(DbContextOptions<AVIewDbContext> options, ILoggerFactory loggerFactory)
            : base(options)
        {
            //Database.EnsureCreated();
            _loggerFactory = loggerFactory;
            //Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WeatherHistory> WeatherHistorys { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {


        }
    }
}

