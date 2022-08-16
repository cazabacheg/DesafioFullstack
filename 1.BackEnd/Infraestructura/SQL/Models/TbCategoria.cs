using System;
using System.Collections.Generic;

#nullable disable

namespace DesafioFullstack.Infraestructura.SQL.Models
{
    public partial class TbCategoria
    {
        public TbCategoria()
        {
            TbProductos = new HashSet<TbProducto>();
        }

        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<TbProducto> TbProductos { get; set; }
    }
}
