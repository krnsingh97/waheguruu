using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication16.Models
{
    public class ToysshopModel : DbContext
    {
        public ToysshopModel(DbContextOptions<ToysshopModel> options) : base(options)

        {
        }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<Shop> Shops { get; set; }


    }
}
