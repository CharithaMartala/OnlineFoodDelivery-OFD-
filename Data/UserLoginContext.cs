using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.Model;

namespace OnlineFoodDelivery.Data
{
    public class UserLoginContext : DbContext
    {
        public UserLoginContext(DbContextOptions<UserLoginContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineFoodDelivery.Model.User> User1 { get; set; } = default!;
        
    }
}
