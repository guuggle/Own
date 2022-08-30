using Own.Domain.Entites;
using System;

namespace Own.Application.Interfaces
{
    public interface ISysUserService
    {
        SysUser GetSysUser(string userId);
    }
}
