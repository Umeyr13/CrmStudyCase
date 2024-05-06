using CustomerRelationsManagementDomain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsManagementPersistence
{
    public class CustomerRelationManagementDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public CustomerRelationManagementDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-V3J8H32; initial catalog = CustomerRelationManagementDb; integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AppUser> Employees { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Suggestion> Suggestion { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Suggestion>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Suggestions);

            builder.Entity<Suggestion>()
                .HasOne(s => s.Employee)
                .WithMany(e => e.Suggestions)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Suggestion>()
                .HasOne(s => s.Sale)
                .WithOne(s => s.Suggestion)
                .HasForeignKey<Sale>(s =>s.SuggestionId);


            builder.Entity<Tasks>()
                .HasOne(t => t.Employee)
                .WithMany(e => e.Tasks)
                .HasForeignKey(e=>e.EmployeeId);
                
            base.OnModelCreating(builder);
        }

    }
}
