using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Impulso.Authorization.Roles;
using Impulso.Authorization.Users;
using Impulso.MultiTenancy;

namespace Impulso.EntityFrameworkCore
{
    public class ImpulsoDbContext : AbpZeroDbContext<Tenant, Role, User, ImpulsoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ImpulsoDbContext(DbContextOptions<ImpulsoDbContext> options)
            : base(options)
        {
        }
    }
}
