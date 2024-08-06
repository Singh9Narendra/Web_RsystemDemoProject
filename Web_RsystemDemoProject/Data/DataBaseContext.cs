using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Web_RsystemDemoProject.Model;
using static Azure.Core.HttpHeader;

namespace Web_RsystemDemoProject.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public DbSet<Stories> Stories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stories>().HasData(new Stories
            {
                StoriesId = 1,
                Title = "storeis-1",
                Url = "demo.com/1"
            });


            modelBuilder.Entity<Stories>().HasData(new Stories
            {
                StoriesId = 2,
                Title = "storeis-2",
                Url = "demo.com/2"
            });

            modelBuilder.Entity<Stories>().HasData(new Stories
            {
                StoriesId = 3,
                Title = "storeis-3",
                Url = "demo.com/3"

            });
            modelBuilder.Entity<Stories>().HasData(new Stories
            {
                StoriesId = 4,
                Title = "storeis-4",
                Url = "demo.com/4"

            });
            modelBuilder.Entity<Stories>().HasData(new Stories
            {
                StoriesId = 5,
                Title = "storeis-5",
                Url = "demo.com/5"

            });

            modelBuilder.Entity<Stories>().HasData(new Stories
            {
                StoriesId = 6,
                Title = "storeis-6",
                Url = "demo.com/6"

            });
            modelBuilder.Entity<Stories>().HasData(new Stories
            {
                StoriesId = 7,
                Title = "storeis-7",
                Url = "demo.com/7"

            });
            modelBuilder.Entity<Stories>().HasData(new Stories
            {
                StoriesId = 8,
                Title = "storeis-8",
                Url = "demo.com/8"

            });
            modelBuilder.Entity<Stories>().HasData(new Stories
            {
                StoriesId = 9,
                Title = "storeis-9",
                Url = "demo.com/9"

            });
            modelBuilder.Entity<Stories>().HasData(new Stories
            {
                StoriesId = 10,
                Title = "storeis-10",
                Url = "demo.com/10"

            });
            modelBuilder.Entity<Stories>().HasData(new Stories
            {
                StoriesId = 11,
                Title = "storeis-11",
                Url = "demo.com/11"

            });
            modelBuilder.Entity<Stories>().HasData(new Stories
            {
                StoriesId = 12,
                Title = "storeis-12",
                Url = "demo.com/12"

            });
            modelBuilder.Entity<Stories>().HasData(new Stories
            {
                StoriesId = 13,
                Title = "storeis-13",
                Url = "demo.com/13"

            });



        }
    

    }

}
