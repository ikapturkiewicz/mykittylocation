using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyKittyLocation.Models
{
    public class KittyLocationContext : DbContext
    {
        public KittyLocationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CatModel> Cats { get; set; }
    }
}
