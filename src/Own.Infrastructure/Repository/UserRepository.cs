using Own.Application.Interfaces;
using Own.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Own.Infrastructure.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly IOwnDbContext _context;

        public UserRepository(IOwnDbContext context)
        {
            this._context = context;
        }

        public async Task<SysUser> GetUser(string userid)
        {
            return await _context.SysUser.FirstOrDefaultAsync(u => u.UserId == userid);
        }
    }
}
