using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//using Dominio.Entity.DesafioFullstack;
using DesafioFullstack.Infraestructura.SQL.Models;

namespace Infraestructura.SQL.Models
{
    public class categoriaDAO
    {
        private DesafioFullstackContext dbc;

        public categoriaDAO(DesafioFullstackContext db)
        {
            dbc = db;
        }

        public List<TbCategoria> listado()
        {
            var auxiliar = dbc.TbCategorias.ToList();

            return auxiliar;
        }
    }
}
