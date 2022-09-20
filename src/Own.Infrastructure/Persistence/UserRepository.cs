using Own.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Own.Application.Common.Interfaces.Persistence;
using Own.Application.Common.Interfaces;

namespace Own.Infrastructure.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly IOwnDbContext _context;

        public UserRepository(IOwnDbContext context)
        {
            this._context = context;
        }

        public async Task AddUser(SysUser user)
        {
            await Task.CompletedTask;
        }

        public async Task<SysUser> GetUserByEmail(string email)
        {
            return await _context.SysUser.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
