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

        public DbSet<Class> Class {get;set;}

        public DbSet<Student> Student {get;set;}
        public DbSet<ClassStudent> ClassStudent {get;set;}

    }
}