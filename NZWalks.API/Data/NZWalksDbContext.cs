using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{   
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
                
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk>  Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Seed Data for Difficulty
            var difficulties = new List<Difficulty>{
                new Difficulty
                {
                    Id   = Guid.Parse("d66f3123-77d1-4109-b4ec-f11a10dafeae") ,
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id   = Guid.Parse("344d623f-88f7-46e4-a3a1-8a6fe433b040") ,
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id   = Guid.Parse("24519670-e2cf-487f-920e-7df823ff0035") ,
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }
    }
    
}
