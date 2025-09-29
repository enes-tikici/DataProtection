using DataProtection.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataProtection.Context
{
    public class DataProtectionDbContext : DbContext
    {

        public DataProtectionDbContext(DbContextOptions<DataProtectionDbContext> options): base (options)
        {
                
        }

        public DbSet<UserEntity> Users { get; set; }

    }
}
