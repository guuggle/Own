using Own.Domain.Entites;
using System;
using System.Threading.Tasks;

namespace Own.Application.Interfaces
{
    public interface IUserService
    {
        Task<SysUser> GetSysUser(string userId);
    }
}
