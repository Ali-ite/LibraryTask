using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LibraryTask.EntityFrameworkCore
{
    public static class LibraryTaskDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LibraryTaskDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LibraryTaskDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
