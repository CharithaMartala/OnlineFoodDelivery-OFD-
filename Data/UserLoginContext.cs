using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserLogin.Model;

namespace UserLogin.Data
{
    public class UserLoginContext : DbContext
    {
        public UserLoginContext(DbContextOptions<UserLoginContext> options)
            : base(options)
        {
        }

        public DbSet<UserLogin.Model.User> User1 { get; set; } = default!;
        
    }
}
