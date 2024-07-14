using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShopping_ELX.Models;

namespace OnlineShopping_ELX.Data
{
    public class OnlineShopping_ELXContext : DbContext
    {
        public OnlineShopping_ELXContext (DbContextOptions<OnlineShopping_ELXContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineShopping_ELX.Models.Category> Category { get; set; } = default!;

        public DbSet<OnlineShopping_ELX.Models.Product>? Product { get; set; }

        public DbSet<OnlineShopping_ELX.Models.User>? User { get; set; }

        public DbSet<OnlineShopping_ELX.Models.BuyProduct>? BuyProduct { get; set; }
    }
}
