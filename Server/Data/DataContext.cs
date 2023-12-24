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
                .IsUnicode(false)
                .HasMaxLength(50);

                emp.Property(e => e.Salary)
                .IsRequired();

                emp.Property(e => e.Email)
                .IsRequired();
            });

            builder.Entity<Department>(dept =>
            {
                dept.HasKey(d => d.Id);
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

    }
}