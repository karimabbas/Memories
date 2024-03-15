using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // public override int SaveChanges()
        // {
        //     var Entities = from e in ChangeTracker.Entries()
        //                    where e.State == EntityState.Modified || e.State == EntityState.Added
        //                    select e.Entity;

        //     var Entities1 = from e in ChangeTracker.Entries()
        //                     where e.State == EntityState.Deleted
        //                     select e.Entity;

        //     foreach (var Entity in Entities)
        //     {
        //         ValidationContext validationContext = new(Entity);
        //         Validator.ValidateObject(Entity, validationContext, true);
        //     }

        //     return base.SaveChanges();
        // }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>(emp =>
            {
                emp.HasKey(e => e.Id);
                emp.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Employee_Name")
                .IsUnicode(true)
                .HasMaxLength(50);

                emp.Property(e => e.Salary)
                .IsRequired();

                emp.Property(e => e.Email)
                .IsRequired();
            });

            builder.Entity<Department>(dept =>
            {
                // dept.HasKey(d => d.Id);
                dept.Property(d => d.Dept_name)
                .IsRequired()
                .HasMaxLength(50);

                dept.Property(d => d.YearOfCreation)
                .IsRequired();
            });

            builder.Entity<Department>()
            .HasMany(E => E.Employees)
            .WithOne(D => D.Department)
            .OnDelete(DeleteBehavior.SetNull);
            // .OnDelete(DeleteBehavior.Cascade);


            // builder.Entity<Employee>()
            // .HasOne(e=>e.Department)
            // .WithMany(e=>e.Employees);

            // builder.Entity<Post>().HasQueryFilter(p=>p.Loves > 4);

            builder.Entity<Department>().HasQueryFilter(d => d.IsDeleted == false);

            // builder.Entity<Blog>().HasMany(p => p.Posts).WithOne(b => b.Blog).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Blog>().HasMany(p => p.Categories).WithOne(b => b.Blog).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CateDesigner>().HasOne(p => p.Categories).WithMany(pr => pr.CateDesigners).OnDelete(DeleteBehavior.Cascade);
            // builder.Entity<CateDesigner>().HasOne(p => p.Reacts).WithMany(pr => pr.PostReacts).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reacts> Reacts { get; set; }
        public DbSet<PostReacts> PostReacts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<EmpActivity> EmpActivities { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Desginer> Desginers { get; set; }
        public DbSet<CateDesigner> CateDesigners { get; set; }
    }
}