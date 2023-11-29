using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using TestAndSuperJest.Models;

namespace TestAndSuperJest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("Listar")]

        public IActionResult listar()
        {
            List<ClassProduct> lista = new();
            try
            {
                using (var conexion = new SqlConnection(Conexion.ConexionString))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_listar_producto", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using var rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        lista.Add(new ClassProduct
                        {
                            idProducto = Convert.ToInt32(rd["idProducto"]),
                            nombre = rd["nombre"].ToString(),
                            precio = Convert.ToInt32(rd["precio"])

                        });
                    }
                }
                return Ok( lista );

            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista );
            }
        
        }
    }
}
