using Abp.IdentityServer4;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XyAuto.It.Authorization.Roles;
using XyAuto.It.Authorization.Users;
using XyAuto.It.EntityMapper.Courseses;
using XyAuto.It.MultiTenancy;
using XyAuto.It.Test;

namespace XyAuto.It.EntityFrameworkCore
{
    public class SecondDbContext : AbpZeroDbContext<Tenant, Role, User, SecondDbContext>, IAbpPersistedGrantDbContext
    {
        public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        public DbSet<Courses> Coursess { get; set; }


        public SecondDbContext(DbContextOptions<SecondDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CoursesCfg());
        }

    }
   
}
