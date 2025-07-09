using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace JobApplicationPortal.EntityFrameworkCore;

public static class JobApplicationPortalDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<JobApplicationPortalDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<JobApplicationPortalDbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}
