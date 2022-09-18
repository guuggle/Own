using Own.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Own.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<SysUser> GetUserByEmail(string email);
        Task AddUser(SysUser user);
    }
}
