using AllBizz.Core.Entities;
using AllBizz.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBizz.Data.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions contextOptions) : base(contextOptions) 
        {
            
        
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SliderConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
