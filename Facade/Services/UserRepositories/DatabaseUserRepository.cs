using Facade.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Services.UserRepositories
{
    public interface IRepository
    {
        Task<User> GetByUsername(string username);
    }

    public class DatabaseUserRepository : IRepository
    {
        private readonly UsersDbContext _context;

        public DatabaseUserRepository(UsersDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
