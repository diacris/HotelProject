using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HotelInvatare.Model
{
    public class OurDbContext : DbContext
    {
        public DbSet <UserAccount> userAccount { get; set; }
    }
}
