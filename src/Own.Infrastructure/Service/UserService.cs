using Own.Application.Interfaces;
using Own.Domain.Entites;
using System;
using System.Threading.Tasks;

namespace Own.Infrastructure.Service
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            this._repo = repo;
        }

        public async Task<SysUser> GetSysUser(string userId)
        {
            return await _repo.GetUser(userId);
        }
    }
}
