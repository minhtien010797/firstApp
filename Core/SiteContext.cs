using firstApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace firstApp.Core
{
    public class SiteContext : IdentityDbContext
    {
        public SiteContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

    }
}