using Microsoft.EntityFrameworkCore;
using ServisTakipWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class ServisTakipDbContext : DbContext
    {
        public ServisTakipDbContext(DbContextOptions<ServisTakipDbContext> options) : base(options)
        {
        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<FaultTrack>? FaultTracks { get; set; }
    }
}