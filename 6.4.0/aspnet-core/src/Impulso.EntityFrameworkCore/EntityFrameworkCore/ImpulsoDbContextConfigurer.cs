using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Impulso.EntityFrameworkCore
{
    public static class ImpulsoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ImpulsoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ImpulsoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
