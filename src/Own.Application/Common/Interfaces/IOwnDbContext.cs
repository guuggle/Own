using Microsoft.EntityFrameworkCore;
using Own.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Own.Application.Common.Interfaces
{
    public interface IOwnDbContext
    {
        DbSet<SysUser> SysUser { get; set; }
    }
}
