using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosCRUD.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required]
        public string Codigo { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required]
        [DisplayName("Precio de venta")]
        public decimal PrecioVenta { get; set; }

        [DisplayName("Categoría")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }
    }
}
