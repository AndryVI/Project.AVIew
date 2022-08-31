using Microsoft.EntityFrameworkCore;
using Project.AVIew.EF.Entities.User;
using System;
using System.Threading.Tasks;

namespace Project.AVIew.EF.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly AVIewDbContext _context;
        public UserRepository(AVIewDbContext dbContext)
             => _context = dbContext;

        public Task<User?> GetUser(string login)
           => _context.Users
                      .FirstOrDefaultAsync(cache => cache.Login == login);

        public async Task AddUser(Guid id, string login, string hashedPin)
        {
            var user = new User()
            {
                Id = id,
                Login = login,
                HashedPin = hashedPin,
                Updated = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}

