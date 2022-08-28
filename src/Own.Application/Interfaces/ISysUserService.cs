using Own.Core;
using System;

namespace Own.Application
{
    public interface ISysUserService
    {
        SysUser GetSysUser(string userId);
    }
}
