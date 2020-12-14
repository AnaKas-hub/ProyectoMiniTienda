using ProyectoMiniTienda.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoMiniTienda.DAL
{
    public class AppDBContext:DbContext
    {
        public AppDBContext():base("DefaultConnection")
        {
        }

        public DbSet<CompraVenta> compraventa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}