using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MyDbContext : DbContext //, IMyDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = default!;

        //public Task<int> SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
