using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosCRUD.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
