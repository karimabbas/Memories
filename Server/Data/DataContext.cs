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

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostReacts> PostReacts { get; set; }

    }
}