using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioFullstack.Infraestructura.SQL.Models;
//using Dominio.Entity.DesafioFullstack;

namespace Infraestructura.SQL.DesafioFullstack
{
    public class productoDAO
    {
        private DesafioFullstackContext dbc;

        public productoDAO(DesafioFullstackContext db)
        {
            dbc = db;
        }

        public List<TbProducto> listado()
        {
            var auxiliar = dbc.TbProductos.ToList();
            //using (SqlConnection cn = new conexionDAO().getcn)

            //{

            //    SqlCommand cmd = new SqlCommand("exec p_producto_listar", cn);
            //    cn.Open();

            //    SqlDataReader dr = cmd.ExecuteReader();

            //    while (dr.Read())
            //    {
            //        auxiliar.Add(new Producto()
            //        {
            //            IdProducto = dr.GetString(0),
            //            NombreProducto = dr.GetString(1),
            //            IdCategoria = dr.GetInt32(2),
            //            PrecioUnidad = Convert.ToDouble(dr.GetDecimal(3))
            //        });
            //    }
            //}
            return auxiliar;
        }

        //public DataTable tabla(DesafioFullstackContext dbc)
        //{
        //    DataTable table = new DataTable();

        //    List<Producto> auxiliar = new List<Producto>();
        //    using (SqlConnection cn = new conexionDAO().getcn)

        //    {
        //        SqlCommand cmd = new SqlCommand("exec p_producto_listar", cn);
        //        cn.Open();

        //        SqlDataReader dr = cmd.ExecuteReader();
        //        table.Load(dr);

        //        dr.Close();
        //        cn.Close();
        //    }
        //    return table;
        //}

        public TbProducto Buscar(string idPro)
        {
            TbProducto prod = dbc.TbProductos.Find(idPro);
            return prod;
        }

        public string Agregar(TbProducto pro)
        {
            string mensaje = "";
            //using (SqlConnection cn = new conexionDAO().getcn)
            //{
            //    cn.Open();

            //    try
            //    {

            //        SqlCommand cmd = new SqlCommand("p_producto_inserta", cn);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.Add("@cod", SqlDbType.VarChar, 7).Direction = ParameterDirection.Output;
            //        cmd.Parameters.AddWithValue("@nomp", pro.NombreProducto);
            //        cmd.Parameters.AddWithValue("@idcategoria", pro.IdCategoria);
            //        cmd.Parameters.AddWithValue("@preUni", pro.PrecioUnidad);

            //        cmd.ExecuteNonQuery();

            //        mensaje = $"Se ha añadido el producto de codigo {cmd.Parameters["@cod"].Value.ToString()}";
            //    }
            //    catch (Exception ex) { mensaje = ex.Message; }
            //    finally { cn.Close(); }
            //}

            dbc.TbProductos.Add(pro);
            var nro = dbc.SaveChanges();

            if (nro > 0)
            {
                mensaje = "Agregado exitosamente";
            }
            else
            {
                mensaje = "No se pudo añadir";
            }
            return mensaje;
        }

        public string Actualizar(TbProducto pro)
        {
            string mensaje = "";

            TbProducto proact = Buscar(pro.IdProducto);

            proact.NombreProducto = pro.NombreProducto;
            proact.IdCategoria = pro.IdCategoria;
            proact.IdCategoriaNavigation = pro.IdCategoriaNavigation;
            proact.PrecioUnidad = pro.PrecioUnidad;

            dbc.Entry(proact).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var nro = dbc.SaveChanges();

            //using (SqlConnection cn = new conexionDAO().getcn)
            //{
            //    cn.Open();
            //    try
            //    {
            //        SqlCommand cmd = new SqlCommand("exec p_producto_actualizar @cod,@nomp,@idcategoria,@preUni", cn);

            //        cmd.Parameters.AddWithValue("@cod", pro.IdProducto);
            //        cmd.Parameters.AddWithValue("@nomp", pro.NombreProducto);
            //        cmd.Parameters.AddWithValue("@idcategoria", pro.IdCategoria);
            //        cmd.Parameters.AddWithValue("@preUni", pro.PrecioUnidad);

            //        cmd.ExecuteNonQuery();

            //        mensaje = $"Se ha modificado la herramienta de codigo {pro.IdProducto}";

            //    }
            //    catch (Exception ex) { mensaje = ex.Message; }
            //    finally { cn.Close(); }
            //}


            if (nro > 0)
            {
                mensaje = "Modificado exitosamente";
            }
            else
            {
                mensaje = "No se pudo modificar";
            }

            return mensaje;
        }

        public string Delete(string idPro)
        {
            string mensaje = "";

            TbProducto prodel = Buscar(idPro);

            dbc.TbProductos.Remove(prodel);
            var nro = dbc.SaveChanges();

            //using (SqlConnection cn = new conexionDAO().getcn)
            //{
            //    try
            //    {
            //        cn.Open();

            //        SqlCommand cmd = new SqlCommand("exec p_producto_delete @cod", cn);
            //        cmd.Parameters.AddWithValue("@cod", idPro);
            //        int i = cmd.ExecuteNonQuery();

            //        mensaje = $"Se ha eliminado {i} producto";
            //    }
            //    catch (Exception ex) { mensaje = ex.Message; }
            //    finally { cn.Close(); }
            //}


            if (nro > 0)
            {
                mensaje = "Eliminado exitosamente";
            }
            else
            {
                mensaje = "No se pudo eliminar";
            }

            return mensaje;
        }
    }
}
