using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;

namespace DHS.Infrastructure.Data.EntityFrameworkCore
{
    public static class DhsDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DhsDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            builder.UseMySql(connectionString,
                new MySqlServerVersion(new Version(8, 0, 23)))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
        }

        public static void Configure(DbContextOptionsBuilder<DhsDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection.ConnectionString,
                new MySqlServerVersion(new Version(8, 0, 23)))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
        }
    }
}
