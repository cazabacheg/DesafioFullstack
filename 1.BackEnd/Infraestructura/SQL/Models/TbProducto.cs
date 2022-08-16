using System;
using System.Collections.Generic;

#nullable disable

namespace DesafioFullstack.Infraestructura.SQL.Models
{
    public partial class TbProducto
    {
        public string IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int? IdCategoria { get; set; }
        public decimal PrecioUnidad { get; set; }

        public virtual TbCategoria IdCategoriaNavigation { get; set; }
    }
}
