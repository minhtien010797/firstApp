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
        public DbSet<ClassStudent> ClassStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClassStudent>()
            .HasKey(ct => new {ct.ClassId, ct.StudentId});

            modelBuilder.Entity<ClassStudent>()
            .HasOne(c => c.Class)
            .WithMany(ct => ct.ClassStudents)
            .HasForeignKey(c => c.ClassId)
            .IsRequired();

            modelBuilder.Entity<ClassStudent>()
            .HasOne(st => st.Student)
            .WithMany(ct => ct.ClassStudents)
            .HasForeignKey(st => st.StudentId)
            .IsRequired();
        }

    }
}