using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RockPaperScissors
{
    public class UserBase : DbContext
    {
        public UserBase()
            : base(@"Data Source = |DataDirectory|UserBase.sdf")
        {
            //Console.WriteLine(Database.Connection.ConnectionString);
        }
        
        public DbSet<User> Users { get; set; }
    }
}
