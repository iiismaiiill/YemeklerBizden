using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yemekoneri.Entities;

namespace yemekoneri.Context
{
    public class YemekOneriDbContext : DbContext
    {
        public YemekOneriDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Yemek> Yemeks { get; set; }
        public DbSet<Yorum> Yorums { get; set; }
        public DbSet<Begen> Begens { get; set; }
    }
}
