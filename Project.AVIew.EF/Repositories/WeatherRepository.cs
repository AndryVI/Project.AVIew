using Microsoft.EntityFrameworkCore;
using Project.AVIew.EF.Entities.User;
using Project.AVIew.EF.Entities.Weather;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.AVIew.EF.Repositories
{
    class WeatherRepository: IWeatherRepository
    {
        private readonly AVIewDbContext _context;
        public WeatherRepository(AVIewDbContext dbContext)
             => _context = dbContext;

        public async Task AddWeatherHistory(List<WeatherHistory> weatherHistory)
        {
            _context.WeatherHistorys.AddRange(weatherHistory);
            await _context.SaveChangesAsync();
        }
    }
}
