using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Data.Models;

namespace Data
{
    public partial class ReactLabContext : DbContext
    {
        public ReactLabContext()
        {
        }

        public ReactLabContext(DbContextOptions<ReactLabContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Store> Stores { get; set; }
    }
}
