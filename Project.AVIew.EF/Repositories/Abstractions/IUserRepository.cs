using Project.AVIew.EF.Entities.User;
using System;
using System.Threading.Tasks;

namespace Project.AVIew.EF.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(Guid id, string login, string hashedPin);
        Task<User?> GetUser(string login);
    }
}
