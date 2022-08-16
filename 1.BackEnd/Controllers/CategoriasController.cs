using Infraestructura.SQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFullstack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        private categoriaDAO cDAO;

        public CategoriasController(Infraestructura.SQL.Models.DesafioFullstackContext db)
        {
            cDAO = new categoriaDAO(db);
        }

        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<Infraestructura.SQL.Models.TbCategoria> lista = cDAO.listado();

                return new JsonResult(lista);
            }
            catch(Exception e)
            {
                return new JsonResult("confirmacion: false, error: " + e);
            }
        }
    }
}
