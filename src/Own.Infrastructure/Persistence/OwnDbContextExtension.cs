using Microsoft.EntityFrameworkCore;
using Own.Application.Common.Interfaces;
using Own.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Own.Infrastructure.Persistence
{
    public partial class OwnDbContext : DbContext, IOwnDbContext
    {
        public DbSet<SysUser> SysUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<MedTemplateTaskConfig>().HasKey(t => new { t.TemplateType, t.TemplateId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
