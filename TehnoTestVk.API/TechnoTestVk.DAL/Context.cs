using Microsoft.EntityFrameworkCore;
using TechnoTestVk.DAL.Models;

namespace TechnoTestVk.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("Host=localhost;Port=5432;Database=TehnoTestVkDb1;Username=postgres;Password=123");
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserGroupEntity> UserGroups { get; set; }
        public DbSet<UserStateEntity> UserStates { get; set; }
    }
}
