using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrixusJa.Data

{
    public class Datacontext :DbContext
    {
        public Datacontext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User
                {
                    username = "mgenius",
                    password = "password",
                    created_at = DateTime.Now
                },

                new User
                {
                    username = "crixus",
                    password = "international",
                    created_at = DateTime.Now
                }

                );
        }
        public DbSet<User> Users { get; set; } 
    }
}
 