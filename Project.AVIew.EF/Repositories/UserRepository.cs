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

        public async Task AddUser(string login, string hashedPin)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Login = login,
                PasswordHashed = hashedPin,
                Updated = DateTime.Now,
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}

