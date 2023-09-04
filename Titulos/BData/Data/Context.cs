using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titulos.BData.Data.Entity;

namespace Titulos.BData.Data
{
    public class Context : DbContext
    {
        public DbSet<Productos> Productos => Set<Productos>();

        public DbSet<Usuarios> Usuarios => Set<Usuarios>();

        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
