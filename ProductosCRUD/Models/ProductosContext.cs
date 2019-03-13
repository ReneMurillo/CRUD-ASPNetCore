using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosCRUD.Models
{
    public class ProductosContext: DbContext
    {
        public ProductosContext(DbContextOptions<ProductosContext> options): base(options)
        {

        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
    }
}
