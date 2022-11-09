using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace CrixusJa.Data
{
    public class User
    {
            [Key]
            public string username { get; set; }
            public string password { get; set; }
            public DateTime created_at { get; set; }

           
       // public DbSet<User> Users { get; set; }
    }
}
