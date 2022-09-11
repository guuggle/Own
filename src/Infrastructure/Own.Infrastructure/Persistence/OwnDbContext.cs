using Microsoft.EntityFrameworkCore;
using Own.Application.Interfaces;
using Own.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Own.Infrastructure.Persistence
{
    public partial class OwnDbContext : DbContext, IOwnDbContext
    {
        public OwnDbContext(DbContextOptions<OwnDbContext> options) : base(options)
        {
        }



    }
}
