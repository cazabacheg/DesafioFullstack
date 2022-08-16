using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.SQL.DesafioFullstack;
//using Dominio.Entity.DesafioFullstack;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using DesafioFullstack.Infraestructura.SQL.Models;

namespace DesafioFullstack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private productoDAO pDAO;

        public ProductosController(Infraestructura.SQL.Models.DesafioFullstackContext db)
        {
            pDAO = new productoDAO(db);
        }

        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<Infraestructura.SQL.Models.TbProducto> lista = pDAO.listado();

                return new JsonResult(lista);
            }
            catch(Exception e)
            {
                return new JsonResult("confirmacion: false, error: " + e);
            }
        }

        [HttpPost]
        public JsonResult Post(TbProducto pro)
        {
            try
            {
                String respuesta = pDAO.Agregar(pro);

                return new JsonResult(respuesta);
            }
            catch(Exception e)
            {
                return new JsonResult("confirmacion: false, error: " + e);
            }
        }

        [HttpPut]
        public JsonResult Put(TbProducto pro)
        {
            try
            {
                String respuesta = pDAO.Actualizar(pro);

                return new JsonResult(respuesta);
            }
            catch(Exception e)
            {
                return new JsonResult("confirmacion: false, error: "+ e);
            }
        }

        [HttpDelete("{idPro}")]
        public JsonResult Delete(String idPro)
        {
            try
            {
                String respuesta = pDAO.Delete(idPro);

                return new JsonResult(respuesta);
            }
            catch (Exception e)
            { 
                return new JsonResult("confirmacion: false, error: " + e);
            }
        }
    }
}
